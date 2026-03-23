namespace StudentJobPlatform.Models
{
    public class User
    {
        private int _id;
        private string _name;
        private string _email;
        private string _password;
        private string _role;

        public int Id => _id;
        public string Name => _name;
        public string Email => _email;
        public string Role => _role;

        public User(int id, string name, string email, string password, string role)
        {
            _id = id;
            _name = name;
            _email = email;
            _password = password;
            _role = role;
        }

        public bool CheckPassword(string password)
        {
            return _password == password;
        }
    }
}