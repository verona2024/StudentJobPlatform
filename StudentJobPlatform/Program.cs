using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;
using StudentJobPlatform.UI;

var userRepo = new FileRepository<User>(@"..\..\..\Files\users.csv");
var jobRepo = new FileRepository<Job>(@"..\..\..\Files\jobs.csv");
var applicationRepo = new FileRepository<Application>(@"..\..\..\Files\applications.csv");
DataSeeder.SeedJobs(jobRepo);
new MenuManager(new JobService(jobRepo), new ApplicationService(applicationRepo, jobRepo)).Start();
