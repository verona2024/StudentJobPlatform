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

        public User? Login(int id, string password)
        {
            var user = _userRepository.GetById(id);

            if (user != null && user.CheckPassword(password))
                return user;

            return null;
        }
    }
}