namespace StudentJobPlatform.Models
{
    public class Job
    {
        private int _id;
        private string _title;
        private string _description;
        private string _category;
        private string _location;
        private string _workingHours;
        private decimal _salary;
        private int _employerId;
        private bool _isActive;

        public int Id => _id;
        public string Title => _title;
        public string Description => _description;
        public string Category => _category;
        public string Location => _location;
        public string WorkingHours => _workingHours;
        public decimal Salary => _salary;
        public int EmployerId => _employerId;
        public bool IsActive => _isActive;

        public Job(int id, string title, string description, string category, string location, string workingHours, decimal salary, int employerId)
        {
            _id = id;
            _title = title;
            _description = description;
            _category = category;
            _location = location;
            _workingHours = workingHours;
            _salary = salary;
            _employerId = employerId;
            _isActive = true;
        }

        public void Activate()
        {
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }

        public override string ToString()
        {
            return $"{_id},{_title},{_description},{_category},{_location},{_workingHours},{_salary},{_employerId}";
        }
    }
}
