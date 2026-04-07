using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.UI
{
    public class StudentMenu
    {
        private readonly JobService _jobService;
        private readonly ApplicationService _applicationService;
        private readonly AuthService? _authService;

        public StudentMenu(JobService jobService, ApplicationService applicationService, AuthService? authService = null)
        {
            _jobService = jobService;
            _applicationService = applicationService;
            _authService = authService;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("=== Student Menu ===");
                Console.WriteLine("1. Shfaq të gjitha punët");
                Console.WriteLine("2. Kërko punë");
                Console.WriteLine("3. Filtro sipas lokacionit");
                Console.WriteLine("4. Filtro sipas kategorisë");
                Console.WriteLine("5. Apliko në punë");
                Console.WriteLine("6. Shfaq punët e rekomanduara");
                Console.WriteLine("7. Përditëso profilin");
                Console.WriteLine("8. Sort by Title (A-Z)");
                Console.WriteLine("9. Sort by Salary (Low to High)");
                Console.WriteLine("10. Sort by Salary (High to Low)");
                Console.WriteLine("0. Kthehu");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowJobs(_jobService.GetAllJobs());
                        break;

                    case "2":
                        SearchJobs();
                        break;

                    case "3":
                        FilterByLocation();
                        break;

                    case "4":
                        FilterByCategory();
                        break;

                    case "5":
                        ApplyToJob();
                        break;

                    case "6":
                        ShowRecommendedJobs();
                        break;

                    case "7":
                        UpdateProfile();
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

        private void ShowJobs(List<Job> jobs)
        {
            if (jobs == null || jobs.Count == 0)
            {
                Console.WriteLine("Nuk ka punë.");
                return;
            }

            foreach (var job in jobs)
            {
                Console.WriteLine($"{job.Id} - {job.Title} - {job.Location} - {job.Salary}€");
            }
        }

        private void SearchJobs()
        {
            Console.Write("Shkruaj fjalën kyçe: ");
            string keyword = Console.ReadLine() ?? "";

            var jobs = _jobService.SearchJobs(keyword);
            ShowJobs(jobs);
        }

        private void FilterByLocation()
        {
            Console.Write("Shkruaj lokacionin: ");
            string location = Console.ReadLine() ?? "";

            var jobs = _jobService.FilterJobsByLocation(location);
            ShowJobs(jobs);
        }

        private void FilterByCategory()
        {
            Console.Write("Shkruaj kategorinë: ");
            string category = Console.ReadLine() ?? "";

            var jobs = _jobService.FilterJobsByCategory(category);
            ShowJobs(jobs);
        }

        private void ApplyToJob()
        {
            Console.Write("Shkruaj Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            Console.Write("Shkruaj Job ID: ");
            if (!int.TryParse(Console.ReadLine(), out int jobId))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            bool success = _applicationService.ApplyToJob(studentId, jobId, out string message);
            Console.WriteLine(message);
        }

        private void ShowRecommendedJobs()
        {
            Console.Write("Shkruaj major: ");
            string major = Console.ReadLine() ?? "";

            Console.Write("Shkruaj skills (ndarë me presje): ");
            string skills = Console.ReadLine() ?? "";

            Console.Write("Shkruaj availability: ");
            string availability = Console.ReadLine() ?? "";

            var jobs = _jobService.GetRecommendedJobs(major, skills, availability);
            ShowJobs(jobs);
        }

        private void UpdateProfile()
        {
            if (_authService == null)
            {
                Console.WriteLine("AuthService nuk është i disponueshëm.");
                return;
            }

            Console.Write("Shkruaj User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Ju lutem shkruani një numër valid.");
                return;
            }

            Console.Write("Shkruaj major: ");
            string major = Console.ReadLine() ?? "";

            Console.Write("Shkruaj skills: ");
            string skills = Console.ReadLine() ?? "";

            Console.Write("Shkruaj location: ");
            string location = Console.ReadLine() ?? "";

            Console.Write("Shkruaj availability: ");
            string availability = Console.ReadLine() ?? "";

            _authService.UpdateProfile(userId, major, skills, location, availability);
            Console.WriteLine("Profili u përditësua me sukses.");
        }
    }
}
