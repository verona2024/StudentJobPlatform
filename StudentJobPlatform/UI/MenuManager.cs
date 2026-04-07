using System;
using StudentJobPlatform.Services;
using StudentJobPlatform.UI;

namespace StudentJobPlatform
{
    public class MenuManager
    {
        private readonly StudentMenu _studentMenu;
        private readonly EmployerMenu _employerMenu;
        private readonly AdminMenu _adminMenu;

        public MenuManager(JobService jobService, ApplicationService applicationService)
        {
            _studentMenu = new StudentMenu(jobService, applicationService);
            _employerMenu = new EmployerMenu(jobService, applicationService);
            _adminMenu = new AdminMenu(jobService, applicationService);
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("=== Student Job Platform ===");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Employer");
                Console.WriteLine("3. Admin");
                Console.WriteLine("0. Dil");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _studentMenu.Start();
                        break;
                    case "2":
                        _employerMenu.Start();
                        break;
                    case "3":
                        _adminMenu.Start();
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
    }
}
