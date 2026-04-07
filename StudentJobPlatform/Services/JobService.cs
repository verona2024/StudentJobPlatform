using System;
using System.Collections.Generic;
using System.Linq;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;

namespace StudentJobPlatform.Services
{
    public class JobService
    {
        private readonly IRepository<Job> _jobRepository;

        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public List<Job> GetAllJobs()
        {
            try
            {
                return _jobRepository.GetAll() ?? new List<Job>();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        public Job? GetJobById(int id)
        {
            try
            {
                if (id <= 0)
                    return null;

                return _jobRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return null;
            }
        }

        public int GetNextJobId()
        {
            try
            {
                var jobs = GetAllJobs();
                return jobs.Any() ? jobs.Max(j => j.Id) + 1 : 1;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return 1;
            }
        }

        public bool AddJob(Job job)
        {
            try
            {
                if (job == null || !IsValidJob(job))
                    return false;

                _jobRepository.Add(job);
                _jobRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return false;
            }
        }

        public bool UpdateJob(Job job)
        {
            try
            {
                if (job == null || !IsValidJob(job))
                    return false;

                var existingJob = _jobRepository.GetById(job.Id);

                if (existingJob == null)
                    return false;

                _jobRepository.Update(job);
                _jobRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return false;
            }
        }

        public bool DeleteJob(int id)
        {
            try
            {
                if (id <= 0)
                    return false;

                var existingJob = _jobRepository.GetById(id);

                if (existingJob == null)
                    return false;

                _jobRepository.Delete(id);
                _jobRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return false;
            }
        }

        public List<Job> GetJobsByEmployer(int employerId)
        {
            try
            {
                if (employerId <= 0)
                    return new List<Job>();

                return GetAllJobs()
                    .Where(j => j.EmployerId == employerId)
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        public List<Job> SearchJobs(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return GetAllJobs();

                keyword = keyword.Trim().ToLower();

                return GetAllJobs()
                    .Where(j =>
                        (!string.IsNullOrWhiteSpace(j.Title) && j.Title.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrWhiteSpace(j.Company) && j.Company.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrWhiteSpace(j.Description) && j.Description.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrWhiteSpace(j.Category) && j.Category.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrWhiteSpace(j.Location) && j.Location.ToLower().Contains(keyword)))
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        public List<Job> GetRecommendedJobs(string major, string skills, string availability)
        {
            try
            {
                var jobs = GetAllJobs();

                if (string.IsNullOrWhiteSpace(major) &&
                    string.IsNullOrWhiteSpace(skills) &&
                    string.IsNullOrWhiteSpace(availability))
                {
                    return jobs;
                }

                string majorLower = (major ?? "").Trim().ToLower();
                string skillsLower = (skills ?? "").Trim().ToLower();
                string availabilityLower = (availability ?? "").Trim().ToLower();

                return jobs.Where(j =>
                        (!string.IsNullOrWhiteSpace(j.Description) && (
                            (!string.IsNullOrWhiteSpace(majorLower) && j.Description.ToLower().Contains(majorLower)) ||
                            (!string.IsNullOrWhiteSpace(skillsLower) && j.Description.ToLower().Contains(skillsLower)) ||
                            (!string.IsNullOrWhiteSpace(availabilityLower) && j.Description.ToLower().Contains(availabilityLower))
                        )) ||
                        (!string.IsNullOrWhiteSpace(j.Title) && (
                            (!string.IsNullOrWhiteSpace(majorLower) && j.Title.ToLower().Contains(majorLower)) ||
                            (!string.IsNullOrWhiteSpace(skillsLower) && j.Title.ToLower().Contains(skillsLower))
                        )) ||
                        (!string.IsNullOrWhiteSpace(j.Category) && (
                            (!string.IsNullOrWhiteSpace(availabilityLower) && j.Category.ToLower().Contains(availabilityLower))
                        )))
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        public List<Job> SortByTitle()
        {
            try
            {
                return GetAllJobs()
                    .OrderBy(j => j.Title)
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        public List<Job> SortBySalaryAsc()
        {
            try
            {
                return GetAllJobs()
                    .OrderBy(j => j.Salary)
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        public List<Job> SortBySalaryDesc()
        {
            try
            {
                return GetAllJobs()
                    .OrderByDescending(j => j.Salary)
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        public List<Job> SortBySalaryAscending()
        {
            return SortBySalaryAsc();
        }

        public List<Job> SortBySalaryDescending()
        {
            return SortBySalaryDesc();
        }

        public List<Job> FilterJobsByLocation(string location)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(location))
                    return GetAllJobs();

                location = location.Trim().ToLower();

                return GetAllJobs()
                    .Where(j =>
                        !string.IsNullOrWhiteSpace(j.Location) &&
                        j.Location.ToLower().Contains(location))
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        public List<Job> FilterJobsByCategory(string category)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(category))
                    return GetAllJobs();

                category = category.Trim().ToLower();

                return GetAllJobs()
                    .Where(j =>
                        !string.IsNullOrWhiteSpace(j.Category) &&
                        j.Category.ToLower().Contains(category))
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Job>();
            }
        }

        private bool IsValidJob(Job job)
        {
            if (string.IsNullOrWhiteSpace(job.Title))
                return false;

            if (string.IsNullOrWhiteSpace(job.Company))
                return false;

            if (string.IsNullOrWhiteSpace(job.Description))
                return false;

            if (string.IsNullOrWhiteSpace(job.Category))
                return false;

            if (string.IsNullOrWhiteSpace(job.Location))
                return false;

            if (string.IsNullOrWhiteSpace(job.WorkingHours))
                return false;

            if (job.Salary <= 0)
                return false;

            if (job.EmployerId <= 0)
                return false;

            return true;
        }
    }
}
