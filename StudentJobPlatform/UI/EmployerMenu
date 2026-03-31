using System;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.UI
{
    public class EmployerMenu
    {
        private readonly JobService _jobService;
        private readonly ApplicationService _applicationService;

        public EmployerMenu(JobService jobService, ApplicationService applicationService)
        {
            _jobService = jobService;
            _applicationService = applicationService;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("=== Employer Menu ===");
                Console.WriteLine("1. Shto punë");
                Console.WriteLine("2. Shfaq të gjitha punët");
                Console.WriteLine("3. Gjej punë sipas ID");
                Console.WriteLine("4. Përditëso punë");
                Console.WriteLine("5. Fshij punë");
                Console.WriteLine("6. Shfaq aplikimet");
                Console.WriteLine("7. Ndrysho statusin e aplikimit");
                Console.WriteLine("0. Kthehu");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddJob();
                        break;
                    case "2":
                        ShowJobs();
                        break;
                    case "3":
                        FindJobById();
                        break;
                    case "4":
                        UpdateJob();
                        break;
                    case "5":
                        DeleteJob();
                        break;
                    case "6":
                        ShowApplications();
                        break;
                    case "7":
                        ChangeApplicationStatus();
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

        private void AddJob()
        {
            Console.Write("Titulli: ");
            string title = Console.ReadLine()!;

            Console.Write("Përshkrimi: ");
            string description = Console.ReadLine()!;

            Console.Write("Kategoria: ");
            string category = Console.ReadLine()!;

            Console.Write("Lokacioni: ");
            string location = Console.ReadLine()!;

            Console.Write("Orari: ");
            string workingHours = Console.ReadLine()!;

            Console.Write("Paga: ");
            decimal salary = decimal.Parse(Console.ReadLine()!);

            int newId = _jobService.GetNextJobId();

            var job = new Job(newId, title, description, category, location, workingHours, salary, 1);
            _jobService.AddJob(job);
        }

        private void ShowJobs()
        {
            var jobs = _jobService.GetAllJobs();

            if (jobs.Count == 0)
            {
                Console.WriteLine("Nuk ka punë të regjistruara.");
                return;
            }

            foreach (var job in jobs)
            {
                Console.WriteLine($"{job.Id} - {job.Title} - {job.Location} - {job.Salary}€");
            }
        }

        private void FindJobById()
        {
            Console.Write("Shkruaj Job ID: ");
            int id = int.Parse(Console.ReadLine()!);

            var job = _jobService.GetJobById(id);

            if (job == null)
            {
                Console.WriteLine("Puna nuk u gjet.");
                return;
            }

            Console.WriteLine($"ID: {job.Id}");
            Console.WriteLine($"Titulli: {job.Title}");
            Console.WriteLine($"Përshkrimi: {job.Description}");
            Console.WriteLine($"Kategoria: {job.Category}");
            Console.WriteLine($"Lokacioni: {job.Location}");
            Console.WriteLine($"Orari: {job.WorkingHours}");
            Console.WriteLine($"Paga: {job.Salary}€");
            Console.WriteLine($"Employer ID: {job.EmployerId}");
            Console.WriteLine($"Aktive: {job.IsActive}");
        }

        private void UpdateJob()
        {
            Console.Write("Shkruaj Job ID që dëshiron ta përditësosh: ");
            int id = int.Parse(Console.ReadLine()!);

            var existingJob = _jobService.GetJobById(id);

            if (existingJob == null)
            {
                Console.WriteLine("Puna nuk u gjet.");
                return;
            }

            Console.Write("Titulli i ri: ");
            string title = Console.ReadLine()!;

            Console.Write("Përshkrimi i ri: ");
            string description = Console.ReadLine()!;

            Console.Write("Kategoria e re: ");
            string category = Console.ReadLine()!;

            Console.Write("Lokacioni i ri: ");
            string location = Console.ReadLine()!;

            Console.Write("Orari i ri: ");
            string workingHours = Console.ReadLine()!;

            Console.Write("Paga e re: ");
            decimal salary = decimal.Parse(Console.ReadLine()!);

            _jobService.UpdateJob(id, title, description, category, location, workingHours, salary, existingJob.EmployerId);
        }

        private void DeleteJob()
        {
            Console.Write("Shkruaj Job ID që dëshiron ta fshish: ");
            int id = int.Parse(Console.ReadLine()!);

            _jobService.DeleteJob(id);
        }

        private void ShowApplications()
        {
            var applications = _applicationService.GetAllApplications();

            if (applications.Count == 0)
            {
                Console.WriteLine("Nuk ka aplikime.");
                return;
            }

            foreach (var application in applications)
            {
                Console.WriteLine($"{application.Id} - Student: {application.StudentId} - Job: {application.JobId} - Status: {application.Status}");
            }
        }

        private void ChangeApplicationStatus()
        {
            Console.Write("Shkruaj Application ID: ");
            int applicationId = int.Parse(Console.ReadLine()!);

            Console.Write("Shkruaj statusin (Accepted / Rejected): ");
            string status = Console.ReadLine()!;

            _applicationService.UpdateApplicationStatus(applicationId, status);
            Console.WriteLine("Statusi u përditësua.");
        }
    }
}
