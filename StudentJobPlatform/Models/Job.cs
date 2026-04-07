namespace StudentJobPlatform.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string WorkingHours { get; set; }
        public decimal Salary { get; set; }
        public int EmployerId { get; set; }
        public bool IsActive { get; set; }

        public Job()
        {
            Title = "";
            Company = "";
            Description = "";
            Category = "";
            Location = "";
            WorkingHours = "";
            IsActive = true;
        }

        public Job(int id, string title, string description, string category, string location, string workingHours, decimal salary, int employerId)
        {
            Id = id;
            Title = title;
            Company = "";
            Description = description;
            Category = category;
            Location = location;
            WorkingHours = workingHours;
            Salary = salary;
            EmployerId = employerId;
            IsActive = true;
        }

        public Job(int id, string title, string company, string description, string category, string location, string workingHours, decimal salary, int employerId)
        {
            Id = id;
            Title = title;
            Company = company;
            Description = description;
            Category = category;
            Location = location;
            WorkingHours = workingHours;
            Salary = salary;
            EmployerId = employerId;
            IsActive = true;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public override string ToString()
        {
            return $"{Id},{Title},{Description},{Category},{Location},{WorkingHours},{Salary},{EmployerId}";
        }
    }
}
