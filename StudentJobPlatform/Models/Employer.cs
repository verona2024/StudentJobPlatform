namespace StudentJobPlatform.Models
{
    public class Employer : User
    {
        private string _companyName;
        private string _businessField;

        public string CompanyName => _companyName;
        public string BusinessField => _businessField;

        public Employer(int id, string name, string email, string password, string companyName, string businessField)
            : base(id, name, email, password, "Employer")
        {
            _companyName = companyName;
            _businessField = businessField;
        }
    }
}