using System;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.UI
{
    public class AdminMenu
    {
        private readonly JobService _jobService;
        private readonly ApplicationService _applicationService;
        private readonly IRepository<User> _userRepository;

        public AdminMenu(JobService jobService, ApplicationService applicationService)
        {
            _jobService = jobService;
            _applicationService = applicationService;
            _userRepository = new FileRepository<User>(@"..\..\..\Files\users.csv");
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("=== Admin Menu ===");
                Console.WriteLine("1. Shfaq të gjitha punët");
                Console.WriteLine("2. Shfaq të gjitha aplikimet");
                Console.WriteLine("3. Shfaq të gjithë përdoruesit");
                Console.WriteLine("0. Kthehu");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowJobs();
                        break;
                    case "2":
                        ShowApplications();
                        break;
                    case "3":
                        ShowUsers();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Zgjedhje e pavlefshme.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void ShowJobs()
        {
            var jobs = _jobService.GetAllJobs();

            foreach (var job in jobs)
            {
                Console.WriteLine($"{job.Id} - {job.Title} - {job.Location} - {job.Salary}€");
            }
        }

        private void ShowApplications()
        {
            var applications = _applicationService.GetAllApplications();

            foreach (var application in applications)
            {
                Console.WriteLine($"{application.Id} - Student: {application.StudentId} - Job: {application.JobId} - Status: {application.Status}");
            }
        }

        private void ShowUsers()
        {
            var users = _userRepository.GetAll();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Name} - {user.Email} - {user.Role}");
            }
        }
    }
}
