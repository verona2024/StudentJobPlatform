using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;

namespace StudentJobPlatform.Services
{
    public class AuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public User? Login(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                    return null;

                var users = _userRepository.GetAll() ?? new List<User>();
                string hashedPassword = HashPassword(password);

                return users.FirstOrDefault(u =>
                    !string.IsNullOrWhiteSpace(u.Email) &&
                    !string.IsNullOrWhiteSpace(u.Password) &&
                    u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                    u.Password == hashedPassword);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return null;
            }
        }

        public void Register(string name, string email, string password, string role)
        {
            try
            {
                ValidateRegisterInput(name, email, password, role);

                var users = _userRepository.GetAll() ?? new List<User>();

                bool emailExists = users.Any(u =>
                    !string.IsNullOrWhiteSpace(u.Email) &&
                    u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

                if (emailExists)
                    throw new Exception("Email ekziston.");

                int newId = users.Any() ? users.Max(u => u.Id) + 1 : 1;
                string hashedPassword = HashPassword(password);

                var newUser = new User(newId, name, email, hashedPassword, role);

                _userRepository.Add(newUser);
                _userRepository.Save();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                throw;
            }
        }

        public User? GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return null;

                return _userRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _userRepository.GetAll() ?? new List<User>();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<User>();
            }
        }

        public bool UpdateProfile(int userId, string major, string skills, string location, string availability)
        {
            try
            {
                if (userId <= 0)
                    return false;

                var user = _userRepository.GetById(userId);

                if (user == null)
                    return false;

                user.Major = major ?? "";
                user.Skills = skills ?? "";
                user.Location = location ?? "";
                user.Availability = availability ?? "";

                _userRepository.Update(user);
                _userRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return false;
            }
        }

        private void ValidateRegisterInput(string name, string email, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Emri nuk mund të jetë bosh.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                throw new Exception("Email nuk është valid.");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new Exception("Password duhet të ketë minimum 6 karaktere.");

            if (string.IsNullOrWhiteSpace(role))
                throw new Exception("Roli nuk mund të jetë bosh.");

            bool validRole =
                role.Equals(Constants.StudentRole, StringComparison.OrdinalIgnoreCase) ||
                role.Equals(Constants.EmployerRole, StringComparison.OrdinalIgnoreCase) ||
                role.Equals(Constants.AdminRole, StringComparison.OrdinalIgnoreCase);

            if (!validRole)
                throw new Exception("Roli nuk është valid.");
        }

        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
