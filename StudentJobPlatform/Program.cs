using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;
using StudentJobPlatform.UI;

var userRepo = new FileRepository<User>(@"..\..\..\Files\users.csv");
var jobRepo = new FileRepository<Job>(@"..\..\..\Files\jobs.csv");
var applicationRepo = new FileRepository<Application>(@"..\..\..\Files\applications.csv");

if (!jobRepo.GetAll().Any())
{
    jobRepo.Add(new Job(1, "Frontend Intern", "Punë part-time për student", "IT", "Mitrovicë", "20 orë/javë", 250, 1));
    jobRepo.Add(new Job(2, "Marketing Assistant", "Punë për studentë", "Marketing", "Prishtinë", "15 orë/javë", 200, 2));
    jobRepo.Save();
}

var menu = new MenuManager(
    new JobService(jobRepo),
    new ApplicationService(applicationRepo, jobRepo)
);

menu.Start();
