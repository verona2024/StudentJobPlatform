using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using System.Reflection;

namespace StudentJobPlatform.Services
{
    public class StudentProfileService
    {
        private readonly IRepository<User> _userRepository;

        public StudentProfileService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User? GetProfile(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public void UpdateProfile(int userId, string major, string skills, string availability)
        {
            var user = _userRepository.GetById(userId);
            if (user == null) return;

            var type = user.GetType();

            var fieldMajor = type.GetField("_major", BindingFlags.NonPublic | BindingFlags.Instance);
            var fieldSkills = type.GetField("_skills", BindingFlags.NonPublic | BindingFlags.Instance);
            var fieldAvailability = type.GetField("_availability", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldMajor != null) fieldMajor.SetValue(user, major);
            if (fieldSkills != null) fieldSkills.SetValue(user, skills);
            if (fieldAvailability != null) fieldAvailability.SetValue(user, availability);

            _userRepository.Save();
        }
    }
}