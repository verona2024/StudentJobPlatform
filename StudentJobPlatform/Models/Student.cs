namespace StudentJobPlatform.Models
{
    public class Student : User
    {
        private string _major;
        private string _skills;

        public new string Major => _major;
        public new string Skills => _skills;

        public Student(int id, string name, string email, string password, string role,
                       string major, string skills)
            : base(id, name, email, password, role)
        {
            _major = major;
            _skills = skills;
        }

        public void UpdateProfile(string major, string skills)
        {
            _major = major;
            _skills = skills;
        }

        public override string ToString()
        {
            return $"{Id},{Name},{Email},{Role},{_major},{_skills}";
        }
    }
}
