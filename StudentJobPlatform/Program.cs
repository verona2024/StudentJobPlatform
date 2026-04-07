using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var jobRepository = new FileRepository<Job>("jobs.json");
            var applicationRepository = new FileRepository<Application>("applications.json");

            var jobService = new JobService(jobRepository);
            var applicationService = new ApplicationService(applicationRepository, jobRepository);

            var menuManager = new MenuManager(jobService, applicationService);
            menuManager.Start();
        }
    }
}
