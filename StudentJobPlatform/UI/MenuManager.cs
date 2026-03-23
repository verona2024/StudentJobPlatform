using System;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.UI
{
    public class MenuManager
    {
        private readonly JobService _jobService;
        private readonly ApplicationService _applicationService;

        public MenuManager(JobService jobService, ApplicationService applicationService)
        {
            _jobService = jobService;
            _applicationService = applicationService;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Student Job Platform");
                Console.WriteLine("1. Shfaq punët");
                Console.WriteLine("2. Apliko në punë");
                Console.WriteLine("0. Dil");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowJobs();
                        break;
                    case "2":
                        ApplyToJob();
                        break;
                    case "0":
                        Console.WriteLine("Dalje nga sistemi.");
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
                Console.WriteLine($"{job.Id} - {job.Title} - {job.Location}");
            }
        }

        private void ApplyToJob()
        {
            Console.Write("Shkruaj Job ID: ");
            int jobId = int.Parse(Console.ReadLine()!);

            _applicationService.ApplyToJob(1, 1, jobId);
            Console.WriteLine("Aplikimi u ruajt.");
        }
    }
}