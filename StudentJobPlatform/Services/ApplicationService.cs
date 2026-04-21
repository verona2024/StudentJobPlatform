using System;
using System.Collections.Generic;
using System.Linq;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;

namespace StudentJobPlatform.Services
{
    public class ApplicationService
    {
        private readonly IRepository<Application> _applicationRepository;
        private readonly IRepository<Job> _jobRepository;

        public ApplicationService(IRepository<Application> applicationRepository, IRepository<Job> jobRepository)
        {
            _applicationRepository = applicationRepository ?? throw new ArgumentNullException(nameof(applicationRepository));
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public List<Application> GetAllApplications()
        {
            try
            {
                return _applicationRepository.GetAll() ?? new List<Application>();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Application>();
            }
        }

        public Application? GetById(int applicationId)
        {
            try
            {
                if (ValidationHelper.IsInvalidId(applicationId))
                    return null;

                return _applicationRepository.GetById(applicationId);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return null;
            }
        }

        public bool HasUserAppliedToJob(int studentId, int jobId)
        {
            try
            {
                if (ValidationHelper.IsInvalidId(studentId) || ValidationHelper.IsInvalidId(jobId))
                    return false;

                return GetAllApplications()
                    .Any(a => a.StudentId == studentId && a.JobId == jobId);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return false;
            }
        }

        public bool ApplyToJob(int studentId, int jobId, out string message)
        {
            try
            {
                if (ValidationHelper.IsInvalidId(studentId))
                {
                    message = "Student ID nuk është valid.";
                    return false;
                }

                if (ValidationHelper.IsInvalidId(jobId))
                {
                    message = "Job ID nuk është valid.";
                    return false;
                }

                var job = _jobRepository.GetById(jobId);

                if (job == null)
                {
                    message = "Job nuk ekziston.";
                    return false;
                }

                if (HasUserAppliedToJob(studentId, jobId))
                {
                    message = "Ke aplikuar tashmë në këtë punë.";
                    return false;
                }

                var applications = GetAllApplications();
                int newId = applications.Any() ? applications.Max(a => a.Id) + 1 : 1;

                var application = new Application(newId, studentId, jobId, DateTime.Now);

                _applicationRepository.Add(application);
                _applicationRepository.Save();

                message = "Aplikimi u krye me sukses!";
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                message = "Ndodhi një gabim gjatë aplikimit.";
                return false;
            }
        }

        public void UpdateApplicationStatus(int applicationId, string newStatus)
        {
            try
            {
                if (ValidationHelper.IsInvalidId(applicationId))
                {
                    Logger.Log("Application ID nuk është valid.");
                    return;
                }

                if (ValidationHelper.IsNullOrWhiteSpace(newStatus))
                {
                    Logger.Log("Statusi nuk mund të jetë bosh.");
                    return;
                }

                bool isValidStatus =
                    newStatus.Equals(Constants.PendingStatus, StringComparison.OrdinalIgnoreCase) ||
                    newStatus.Equals(Constants.AcceptedStatus, StringComparison.OrdinalIgnoreCase) ||
                    newStatus.Equals(Constants.RejectedStatus, StringComparison.OrdinalIgnoreCase);

                if (!isValidStatus)
                {
                    Logger.Log("Statusi nuk është valid.");
                    return;
                }

                var application = _applicationRepository.GetById(applicationId);

                if (application == null)
                {
                    Logger.Log("Aplikimi nuk u gjet.");
                    return;
                }

                application.UpdateStatus(newStatus);
                _applicationRepository.Update(application);
                _applicationRepository.Save();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }

        public List<Application> GetApplicationsByStudent(int studentId)
        {
            try
            {
                if (ValidationHelper.IsInvalidId(studentId))
                    return new List<Application>();

                return GetAllApplications()
                    .Where(a => a.StudentId == studentId)
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Application>();
            }
        }

        public List<Application> GetApplicationsByJob(int jobId)
        {
            try
            {
                if (ValidationHelper.IsInvalidId(jobId))
                    return new List<Application>();

                return GetAllApplications()
                    .Where(a => a.JobId == jobId)
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Application>();
            }
        }

        public void DeleteApplication(int applicationId)
        {
            try
            {
                if (ValidationHelper.IsInvalidId(applicationId))
                {
                    Logger.Log("Application ID nuk është valid.");
                    return;
                }

                var application = _applicationRepository.GetById(applicationId);

                if (application == null)
                {
                    Logger.Log("Aplikimi nuk u gjet.");
                    return;
                }

                _applicationRepository.Delete(applicationId);
                _applicationRepository.Save();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }
    }
}