namespace StudentJobPlatform.Models
{
    public class Application
    {
        private int _id;
        private int _studentId;
        private int _jobId;
        private DateTime _applicationDate;
        private string _status;

        public int Id => _id;
        public int StudentId => _studentId;
        public int JobId => _jobId;
        public DateTime ApplicationDate => _applicationDate;
        public string Status => _status;

        public Application(int id, int studentId, int jobId, DateTime applicationDate)
        {
            _id = id;
            _studentId = studentId;
            _jobId = jobId;
            _applicationDate = applicationDate;
            _status = "Pending";
        }

        public void UpdateStatus(string status)
        {
            _status = status;
        }

        public override string ToString()
        {
            return $"{_id},{_studentId},{_jobId},{_applicationDate},{_status}";
        }
    }
}