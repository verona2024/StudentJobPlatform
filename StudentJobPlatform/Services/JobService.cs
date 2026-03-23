using System.Collections.Generic;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;

namespace StudentJobPlatform.Services
{
    public class JobService
    {
        private readonly IRepository<Job> _jobRepository;

        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public List<Job> GetAllJobs()
        {
            return _jobRepository.GetAll();
        }

        public Job? GetJobById(int id)
        {
            return _jobRepository.GetById(id);
        }

        public void AddJob(Job job)
        {
            _jobRepository.Add(job);
            _jobRepository.Save();
        }
    }
}