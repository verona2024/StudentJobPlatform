namespace StudentJobPlatform;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;
using StudentJobPlatform.UI;
public class Program
{  public static void Main()
    {   var userRepo = new FileRepository<User>(@"..\..\..\Files\users.csv"); var jobRepo = new FileRepository<Job>(@"..\..\..\Files\jobs.csv"); var appRepo = new FileRepository<Application>(@"..\..\..\Files\applications.csv");
        AppServices.JobService = new JobService(jobRepo); AppServices.ApplicationService = new ApplicationService(appRepo, jobRepo); AppServices.AuthService = new AuthService(userRepo);
        DataSeeder.SeedJobs(jobRepo); new AuthMenu(AppServices.AuthService).Start();}}
