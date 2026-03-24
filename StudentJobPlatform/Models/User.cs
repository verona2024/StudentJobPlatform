namespace StudentJobPlatform.Models
{
    public class User
    {
        private int _id;
        private string _name;
        private string _email;
        private string _password;
        private string _role;
        private string _major;
        private string _skills;
        private string _availability;

        public int Id => _id;
        public string Name => _name;
        public string Email => _email;
        public string Role => _role;
        public string Major => _major;
        public string Skills => _skills;
        public string Availability => _availability;

        public User(int id, string name, string email, string password, string role)
        {
            _id = id;
            _name = name;
            _email = email;
            _password = password;
            _role = role;
            _major = "";
            _skills = "";
            _availability = "";
        }

        public bool CheckPassword(string password)
        {
            return _password == password;
        }

        public override string ToString()
        {
            return $"{_id},{_name},{_email},{_password},{_role},{_major},{_skills},{_availability}";
        }
    }
}
