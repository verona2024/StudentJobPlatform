using System.Linq;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;

namespace StudentJobPlatform.Services
{
    public class AuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Login(string email, string password)
        {
            var users = _userRepository.GetAll();

            return users.FirstOrDefault(u =>
                u.Email == email && u.CheckPassword(password));
        }

        public void Register(User user)
        {
            _userRepository.Add(user);
            _userRepository.Save();
        }

        public int GetNextUserId()
        {
            var users = _userRepository.GetAll();

            if (!users.Any())
                return 1;

            return users.Max(u => u.Id) + 1;
        }
    }
}
