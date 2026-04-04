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
            if (string.IsNullOrWhiteSpace(job.Title))
            {
                Console.WriteLine("Titulli nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.Description))
            {
                Console.WriteLine("Përshkrimi nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.Category))
            {
                Console.WriteLine("Kategoria nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.Location))
            {
                Console.WriteLine("Lokacioni nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.WorkingHours))
            {
                Console.WriteLine("Orari i punës nuk mund të jetë bosh.");
                return;
            }

            if (job.Salary <= 0)
            {
                Console.WriteLine("Paga duhet të jetë më e madhe se 0.");
                return;
            }

            _jobRepository.Add(job);
            _jobRepository.Save();
            Console.WriteLine("Puna u shtua me sukses.");
        }

        public void UpdateJob(int id, string title, string description, string category, string location, string workingHours, decimal salary, int employerId)
        {
            var existingJob = _jobRepository.GetById(id);

            if (existingJob == null)
            {
                Console.WriteLine("Puna nuk u gjet.");
                return;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Titulli nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Përshkrimi nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Kategoria nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                Console.WriteLine("Lokacioni nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(workingHours))
            {
                Console.WriteLine("Orari i punës nuk mund të jetë bosh.");
                return;
            }

            if (salary <= 0)
            {
                Console.WriteLine("Paga duhet të jetë më e madhe se 0.");
                return;
            }

            var updatedJob = new Job(id, title, description, category, location, workingHours, salary, employerId);

            if (!existingJob.IsActive)
            {
                updatedJob.Deactivate();
            }

            _jobRepository.Update(updatedJob);
            Console.WriteLine("Puna u përditësua me sukses.");
        }

        public void DeleteJob(int id)
        {
            var existingJob = _jobRepository.GetById(id);

            if (existingJob == null)
            {
                Console.WriteLine("Puna nuk u gjet.");
                return;
            }

            _jobRepository.Delete(id);
            Console.WriteLine("Puna u fshi me sukses.");
        }

        public List<Job> SearchJobs(string keyword)
        {
            return _jobRepository.GetAll()
                .Where(j =>
                    j.Title.ToLower().Contains(keyword.ToLower()) ||
                    j.Description.ToLower().Contains(keyword.ToLower()) ||
                    j.Category.ToLower().Contains(keyword.ToLower()) ||
                    j.Location.ToLower().Contains(keyword.ToLower()))
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

        public List<Job> SortByTitle()
        {
            return _jobRepository.GetAll()
                .OrderBy(j => j.Title)
                .ToList();
        }

        public int GetNextJobId()
        {
            var jobs = _jobRepository.GetAll();

            if (!jobs.Any())
                return 1;

            return jobs.Max(j => j.Id) + 1;
        }
    }
}            {
                Console.WriteLine("Përshkrimi nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.Category))
            {
                Console.WriteLine("Kategoria nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.Location))
            {
                Console.WriteLine("Lokacioni nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.WorkingHours))
            {
                Console.WriteLine("Orari i punës nuk mund të jetë bosh.");
                return;
            }

            if (job.Salary <= 0)
            {
                Console.WriteLine("Paga duhet të jetë më e madhe se 0.");
                return;
            }

            _jobRepository.Add(job);
            _jobRepository.Save();
            Console.WriteLine("Puna u shtua me sukses.");
        }

        public void UpdateJob(int id, string title, string description, string category, string location, string workingHours, decimal salary, int employerId)
        {
            var existingJob = _jobRepository.GetById(id);

            if (existingJob == null)
            {
                Console.WriteLine("Puna nuk u gjet.");
                return;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Titulli nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Përshkrimi nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Kategoria nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                Console.WriteLine("Lokacioni nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(workingHours))
            {
                Console.WriteLine("Orari i punës nuk mund të jetë bosh.");
                return;
            }

            if (salary <= 0)
            {
                Console.WriteLine("Paga duhet të jetë më e madhe se 0.");
                return;
            }

            var updatedJob = new Job(id, title, description, category, location, workingHours, salary, employerId);

            if (!existingJob.IsActive)
            {
                updatedJob.Deactivate();
            }

            _jobRepository.Update(updatedJob);
            Console.WriteLine("Puna u përditësua me sukses.");
        }

        public void DeleteJob(int id)
        {
            var existingJob = _jobRepository.GetById(id);

            if (existingJob == null)
            {
                Console.WriteLine("Puna nuk u gjet.");
                return;
            }

            _jobRepository.Delete(id);
            Console.WriteLine("Puna u fshi me sukses.");
        }

        public List<Job> SearchJobs(string keyword)
        {
            return _jobRepository.GetAll()
                .Where(j =>
                    j.Title.ToLower().Contains(keyword.ToLower()) ||
                    j.Description.ToLower().Contains(keyword.ToLower()) ||
                    j.Category.ToLower().Contains(keyword.ToLower()) ||
                    j.Location.ToLower().Contains(keyword.ToLower()))
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

        public List<Job> SortByTitle()
        {
            return _jobRepository.GetAll()
                .OrderBy(j => j.Title)
                .ToList();
        }

        public int GetNextJobId()
        {
            var jobs = _jobRepository.GetAll();

            if (!jobs.Any())
                return 1;

            return jobs.Max(j => j.Id) + 1;
        }
    }
}            {
                Console.WriteLine("Përshkrimi nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.Category))
            {
                Console.WriteLine("Kategoria nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.Location))
            {
                Console.WriteLine("Lokacioni nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(job.WorkingHours))
            {
                Console.WriteLine("Orari i punës nuk mund të jetë bosh.");
                return;
            }

            if (job.Salary <= 0)
            {
                Console.WriteLine("Paga duhet të jetë më e madhe se 0.");
                return;
            }

            _jobRepository.Add(job);
            _jobRepository.Save();
            Console.WriteLine("Puna u shtua me sukses.");
        }

        public void UpdateJob(int id, string title, string description, string category, string location, string workingHours, decimal salary, int employerId)
        {
            var existingJob = _jobRepository.GetById(id);

            if (existingJob == null)
            {
                Console.WriteLine("Puna nuk u gjet.");
                return;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Titulli nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Përshkrimi nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Kategoria nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                Console.WriteLine("Lokacioni nuk mund të jetë bosh.");
                return;
            }

            if (string.IsNullOrWhiteSpace(workingHours))
            {
                Console.WriteLine("Orari i punës nuk mund të jetë bosh.");
                return;
            }

            if (salary <= 0)
            {
                Console.WriteLine("Paga duhet të jetë më e madhe se 0.");
                return;
            }

            var updatedJob = new Job(id, title, description, category, location, workingHours, salary, employerId);

            if (!existingJob.IsActive)
            {
                updatedJob.Deactivate();
            }

            _jobRepository.Update(updatedJob);
            Console.WriteLine("Puna u përditësua me sukses.");
        }

        public void DeleteJob(int id)
        {
            var existingJob = _jobRepository.GetById(id);

            if (existingJob == null)
            {
                Console.WriteLine("Puna nuk u gjet.");
                return;
            }

            _jobRepository.Delete(id);
            Console.WriteLine("Puna u fshi me sukses.");
        }

        public List<Job> SearchJobs(string keyword)
        {
            return _jobRepository.GetAll()
                .Where(j =>
                    j.Title.ToLower().Contains(keyword.ToLower()) ||
                    j.Description.ToLower().Contains(keyword.ToLower()) ||
                    j.Category.ToLower().Contains(keyword.ToLower()) ||
                    j.Location.ToLower().Contains(keyword.ToLower()))
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

        public int GetNextJobId()
        {
            var jobs = _jobRepository.GetAll();

            if (!jobs.Any())
                return 1;

            return jobs.Max(j => j.Id) + 1;
        }
    }
}
