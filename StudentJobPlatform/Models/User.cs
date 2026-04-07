namespace StudentJobPlatform.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Major { get; set; }
        public string Skills { get; set; }
        public string Location { get; set; }
        public string Availability { get; set; }

        public User()
        {
            Name = "";
            Email = "";
            Password = "";
            Role = "";
            Major = "";
            Skills = "";
            Location = "";
            Availability = "";
        }

        public User(int id, string name, string email, string password, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Major = "";
            Skills = "";
            Location = "";
            Availability = "";
        }
    }
}