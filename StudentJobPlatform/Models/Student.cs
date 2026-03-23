namespace StudentJobPlatform.Models
{
    public class Student : User
    {
        private string _fieldOfStudy;
        private string _skills;
        private string _location;

        public string FieldOfStudy => _fieldOfStudy;
        public string Skills => _skills;
        public string Location => _location;

        public Student(int id, string name, string email, string password, string fieldOfStudy, string skills, string location)
            : base(id, name, email, password, "Student")
        {
            _fieldOfStudy = fieldOfStudy;
            _skills = skills;
            _location = location;
        }

        public void UpdateProfile(string fieldOfStudy, string skills, string location)
        {
            _fieldOfStudy = fieldOfStudy;
            _skills = skills;
            _location = location;
        }
    }
}