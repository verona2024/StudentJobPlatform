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

        public List<Job> SearchJobs(string keyword)
        {
            return _jobRepository.GetAll()
                .Where(j => j.Title.ToLower().Contains(keyword.ToLower())
                         || j.Description.ToLower().Contains(keyword.ToLower())
                         || j.Category.ToLower().Contains(keyword.ToLower())
                         || j.Location.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }

        public List<Job> FilterJobsByLocation(string location)
        {
            return _jobRepository.GetAll()
                .Where(j => j.Location.ToLower() == location.ToLower())
                .ToList();
        }

        public List<Job> FilterJobsByCategory(string category)
        {
            return _jobRepository.GetAll()
                .Where(j => j.Category.ToLower() == category.ToLower())
                .ToList();
        }

        public List<Job> GetRecommendedJobs(string major, string skills)
        {
            return _jobRepository.GetAll()
                .Where(j =>
                    j.Category.ToLower().Contains(major.ToLower()) ||
                    skills.ToLower().Split(',').Any(skill =>
                        j.Title.ToLower().Contains(skill.Trim().ToLower()) ||
                        j.Description.ToLower().Contains(skill.Trim().ToLower()) ||
                        j.Category.ToLower().Contains(skill.Trim().ToLower())
                    )
                )
                .ToList();
        }
    }
}
