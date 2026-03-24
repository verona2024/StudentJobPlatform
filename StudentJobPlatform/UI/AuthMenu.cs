using System;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.UI
{
    public class AuthMenu
    {
        private readonly AuthService _authService;

        public AuthMenu(AuthService authService)
        {
            _authService = authService;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("=== Authentication Menu ===");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Kthehu");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Login();
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

        private void Register()
        {
            Console.Write("Emri: ");
            string name = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            string role;
            while (true)
            {
                Console.Write("Roli (Student / Employer / Admin): ");
                role = Console.ReadLine()!;

                if (role == "Student" || role == "Employer" || role == "Admin")
                    break;

                Console.WriteLine("Shkruaj vetëm: Student, Employer ose Admin");
            }

            int id = _authService.GetNextUserId();

            var user = new User(id, name, email, password, role);

            _authService.Register(user);

            Console.WriteLine("Llogaria u krijua me sukses.");
        }

        private void Login()
        {
            Console.Write("User ID: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            var user = _authService.Login(id, password);

            if (user == null)
            {
                Console.WriteLine("Login dështoi.");
            }
            else
            {
                Console.WriteLine($"Mirë se erdhe {user.Name} ({user.Role})");

                SessionManager.CurrentUserId = user.Id;
                SessionManager.CurrentUserRole = user.Role;
                SessionManager.CurrentUserName = user.Name;

                if (user.Role == "Student")
                {
                    var studentMenu = new StudentMenu(
                        AppServices.JobService,
                        AppServices.ApplicationService);

                    studentMenu.Start();
                }
                else if (user.Role == "Employer")
                {
                    var employerMenu = new EmployerMenu(
                        AppServices.JobService,
                        AppServices.ApplicationService);

                    employerMenu.Start();
                }
                else
                {
                    var adminMenu = new AdminMenu(
                        AppServices.JobService,
                        AppServices.ApplicationService);

                    adminMenu.Start();
                }
            }
        }
    }
}
