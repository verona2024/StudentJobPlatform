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
                Console.WriteLine("=== Auth Menu ===");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Logout");
                Console.WriteLine("0. Dil");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;

                    case "2":
                        if (Login())
                            return;
                        break;

                    case "3":
                        Logout();
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opsion i pavlefshëm.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void Register()
        {
            Console.Write("Emri: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            Console.Write("Roli (Student/Employer/Admin): ");
            string role = Console.ReadLine() ?? "";

            try
            {
                _authService.Register(name, email, password, role);
                Console.WriteLine("Regjistrimi u krye me sukses.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim: {ex.Message}");
            }
        }

        private bool Login()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            User? user = _authService.Login(email, password);

            if (user == null)
            {
                Console.WriteLine("Login dështoi.");
                return false;
            }

            SessionManager.Login(user.Id, user.Name, user.Role);
            Console.WriteLine($"Mirë se erdhe, {user.Name}! ({user.Role})");
            return true;
        }

        private void Logout()
        {
            SessionManager.Logout();
            Console.WriteLine("Logout me sukses.");
        }
    }
}