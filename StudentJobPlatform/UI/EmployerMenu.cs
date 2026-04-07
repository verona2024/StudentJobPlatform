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
                Console.WriteLine("2. Shfaq punët e mia");
                Console.WriteLine("3. Gjej punë sipas ID");
                Console.WriteLine("4. Përditëso punë");
                Console.WriteLine("5. Fshij punë");
                Console.WriteLine("6. Shfaq aplikimet");
                Console.WriteLine("7. Ndrysho statusin e aplikimit");
                Console.WriteLine("8. Sort by Title (A-Z)");
                Console.WriteLine("9. Sort by Salary (Low to High)");
                Console.WriteLine("10. Sort by Salary (High to Low)");
                Console.WriteLine("0. Kthehu");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddJob();
                        break;

                    case "2":
                        ShowMyJobs();
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

                    case "8":
                        ShowJobs(_jobService.SortByTitle());
                        break;

                    case "9":
                        ShowJobs(_jobService.SortBySalaryAsc());
                        break;

                    case "10":
                        ShowJobs(_jobService.SortBySalaryDesc());
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
            Console.Write("Shkruaj Employer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employerId))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            Console.Write("Titulli: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Kompania: ");
            string company = Console.ReadLine() ?? "";

            Console.Write("Përshkrimi: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Kategoria: ");
            string category = Console.ReadLine() ?? "";

            Console.Write("Lokacioni: ");
            string location = Console.ReadLine() ?? "";

            Console.Write("Orari: ");
            string workingHours = Console.ReadLine() ?? "";

            Console.Write("Paga: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                Console.WriteLine("Ju lutem shkruani një pagë valide.");
                return;
            }

            int newId = _jobService.GetNextJobId();

            var job = new Job(newId, title, company, description, category, location, workingHours, salary, employerId);

            if (_jobService.AddJob(job))
                Console.WriteLine("Puna u shtua me sukses.");
            else
                Console.WriteLine("Puna nuk u shtua. Kontrollo të dhënat.");
        }

        private void ShowMyJobs()
        {
            Console.Write("Shkruaj Employer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employerId))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            var jobs = _jobService.GetJobsByEmployer(employerId);
            ShowJobs(jobs);
        }

        private void ShowJobs(List<Job> jobs)
        {
            if (jobs == null || jobs.Count == 0)
            {
                Console.WriteLine("Nuk ka punë.");
                return;
            }

            foreach (var job in jobs)
            {
                Console.WriteLine($"{job.Id} - {job.Title} - {job.Company} - {job.Location} - {job.Salary}€");
            }
        }

        private void FindJobById()
        {
            Console.Write("Shkruaj Job ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            var job = _jobService.GetJobById(id);

            if (job == null)
            {
                Console.WriteLine("Itemi nuk u gjet.");
                return;
            }

            Console.WriteLine($"ID: {job.Id}");
            Console.WriteLine($"Titulli: {job.Title}");
            Console.WriteLine($"Kompania: {job.Company}");
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
            Console.Write("Shkruaj Employer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employerId))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            Console.Write("Shkruaj Job ID që dëshiron ta përditësosh: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            var existingJob = _jobService.GetJobById(id);

            if (existingJob == null)
            {
                Console.WriteLine("Itemi nuk u gjet.");
                return;
            }

            if (existingJob.EmployerId != employerId)
            {
                Console.WriteLine("Nuk ke të drejtë të përditësosh këtë punë.");
                return;
            }

            Console.Write("Titulli i ri: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Kompania e re: ");
            string company = Console.ReadLine() ?? "";

            Console.Write("Përshkrimi i ri: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Kategoria e re: ");
            string category = Console.ReadLine() ?? "";

            Console.Write("Lokacioni i ri: ");
            string location = Console.ReadLine() ?? "";

            Console.Write("Orari i ri: ");
            string workingHours = Console.ReadLine() ?? "";

            Console.Write("Paga e re: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                Console.WriteLine("Ju lutem shkruani një pagë valide.");
                return;
            }

            var updatedJob = new Job(id, title, company, description, category, location, workingHours, salary, employerId);

            if (_jobService.UpdateJob(updatedJob))
                Console.WriteLine("Puna u përditësua me sukses.");
            else
                Console.WriteLine("Puna nuk u përditësua.");
        }

        private void DeleteJob()
        {
            Console.Write("Shkruaj Employer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employerId))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            Console.Write("Shkruaj Job ID që dëshiron ta fshish: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            var job = _jobService.GetJobById(id);

            if (job == null)
            {
                Console.WriteLine("Itemi nuk u gjet.");
                return;
            }

            if (job.EmployerId != employerId)
            {
                Console.WriteLine("Nuk ke të drejtë të fshish këtë punë.");
                return;
            }

            if (_jobService.DeleteJob(id))
                Console.WriteLine("Puna u fshi me sukses.");
            else
                Console.WriteLine("Puna nuk u fshi.");
        }

        private void ShowApplications()
        {
            var applications = _applicationService.GetAllApplications();

            if (applications == null || applications.Count == 0)
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
            if (!int.TryParse(Console.ReadLine(), out int applicationId))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            Console.Write("Shkruaj statusin (Accepted / Rejected): ");
            string status = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(status))
            {
                Console.WriteLine("Statusi nuk mund të jetë bosh.");
                return;
            }

            if (!status.Equals("Accepted", StringComparison.OrdinalIgnoreCase) &&
                !status.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Statusi duhet të jetë vetëm Accepted ose Rejected.");
                return;
            }

            _applicationService.UpdateApplicationStatus(applicationId, status);
        }
    }
}