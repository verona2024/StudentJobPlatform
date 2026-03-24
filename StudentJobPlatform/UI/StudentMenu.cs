using System;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.UI
{
    public class StudentMenu
    {
        private readonly JobService _jobService;
        private readonly ApplicationService _applicationService;
        private readonly StudentProfileService _profileService;

        public StudentMenu(JobService jobService, ApplicationService applicationService)
        {
            _jobService = jobService;
            _applicationService = applicationService;
            _profileService = new StudentProfileService(
                new StudentJobPlatform.Data.FileRepository<User>(@"..\..\..\Files\users.csv")
            );
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("=== Student Menu ===");
                Console.WriteLine("1. Shfaq të gjitha punët");
                Console.WriteLine("2. Apliko në punë");
                Console.WriteLine("3. My Applications");
                Console.WriteLine("4. Search Jobs");
                Console.WriteLine("5. Filter Jobs");
                Console.WriteLine("6. Create/Update Profile");
                Console.WriteLine("7. View Profile");
                Console.WriteLine("8. Recommended Jobs");
                Console.WriteLine("0. Kthehu");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowJobs();
                        break;
                    case "2":
                        ApplyToJob();
                        break;
                    case "3":
                        ShowMyApplications();
                        break;
                    case "4":
                        SearchJobs();
                        break;
                    case "5":
                        FilterJobs();
                        break;
                    case "6":
                        CreateProfile();
                        break;
                    case "7":
                        ViewProfile();
                        break;
                    case "8":
                        ShowRecommendedJobs();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Gabim.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void ShowJobs()
        {
            foreach (var job in _jobService.GetAllJobs())
            {
                Console.WriteLine($"{job.Id} - {job.Title} - {job.Location} - {job.Salary}€");
            }
        }

        private void ApplyToJob()
        {
            Console.Write("Job ID: ");
            int jobId = int.Parse(Console.ReadLine()!);

            int newId = _applicationService.GetAllApplications().Count + 1;

            _applicationService.ApplyToJob(newId, SessionManager.CurrentUserId, jobId);

            Console.WriteLine("Aplikimi u ruajt.");
        }

        private void ShowMyApplications()
        {
            var apps = _applicationService.GetAllApplications();
            bool found = false;

            foreach (var app in apps)
            {
                if (app.StudentId == SessionManager.CurrentUserId)
                {
                    Console.WriteLine($"App {app.Id} - Job {app.JobId} - {app.Status}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Nuk ke aplikime.");
            }
        }

        private void SearchJobs()
        {
            Console.Write("Keyword: ");
            string keyword = Console.ReadLine()!;

            var results = _jobService.SearchJobs(keyword);

            if (results.Count == 0)
            {
                Console.WriteLine("Asnjë punë nuk u gjet.");
                return;
            }

            foreach (var job in results)
            {
                Console.WriteLine($"{job.Id} - {job.Title} - {job.Location}");
            }
        }

        private void FilterJobs()
        {
            Console.WriteLine("1. Lokacion");
            Console.WriteLine("2. Kategori");

            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Lokacion: ");
                string loc = Console.ReadLine()!;
                var jobs = _jobService.FilterJobsByLocation(loc);

                if (jobs.Count == 0)
                {
                    Console.WriteLine("Nuk u gjet asnjë punë.");
                    return;
                }

                foreach (var j in jobs)
                    Console.WriteLine($"{j.Id} - {j.Title}");
            }
            else if (choice == "2")
            {
                Console.Write("Kategori: ");
                string cat = Console.ReadLine()!;
                var jobs = _jobService.FilterJobsByCategory(cat);

                if (jobs.Count == 0)
                {
                    Console.WriteLine("Nuk u gjet asnjë punë.");
                    return;
                }

                foreach (var j in jobs)
                    Console.WriteLine($"{j.Id} - {j.Title}");
            }
        }

        private void CreateProfile()
        {
            Console.Write("Drejtimi: ");
            string major = Console.ReadLine()!;

            Console.Write("Skills: ");
            string skills = Console.ReadLine()!;

            Console.Write("Orari i lirë / availability: ");
            string availability = Console.ReadLine()!;

            _profileService.UpdateProfile(SessionManager.CurrentUserId, major, skills, availability);

            Console.WriteLine("Profili u ruajt.");
        }

        private void ViewProfile()
        {
            var user = _profileService.GetProfile(SessionManager.CurrentUserId);

            if (user == null)
            {
                Console.WriteLine("S’ka profil.");
                return;
            }

            Console.WriteLine($"Drejtimi: {user.Major}");
            Console.WriteLine($"Skills: {user.Skills}");
            Console.WriteLine($"Availability: {user.Availability}");
        }

        private void ShowRecommendedJobs()
        {
            var user = _profileService.GetProfile(SessionManager.CurrentUserId);

            if (user == null)
            {
                Console.WriteLine("Krijo profilin.");
                return;
            }

            var jobs = _jobService.GetRecommendedJobs(user.Major, user.Skills);

            if (jobs.Count == 0)
            {
                Console.WriteLine("Nuk ka rekomandime.");
                return;
            }

            foreach (var j in jobs)
            {
                Console.WriteLine($"{j.Id} - {j.Title}");
            }
        }
    }
}
