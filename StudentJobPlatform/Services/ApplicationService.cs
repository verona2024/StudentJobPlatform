using System;
using System.Collections.Generic;
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
            _applicationRepository = applicationRepository;
            _jobRepository = jobRepository;
        }

        public List<Application> GetAllApplications()
        {
            return _applicationRepository.GetAll();
        }

        public void ApplyToJob(int applicationId, int studentId, int jobId)
        {
            var job = _jobRepository.GetById(jobId);

            if (job == null || !job.IsActive)
            {
                Console.WriteLine("Puna nuk ekziston ose nuk është aktive.");
                return;
            }

            var application = new Application(applicationId, studentId, jobId, DateTime.Now);
            _applicationRepository.Add(application);
            _applicationRepository.Save();
        }
    }
}