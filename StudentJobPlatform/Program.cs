using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;
using StudentJobPlatform.UI;

var userRepo = new FileRepository<User>();
var jobRepo = new FileRepository<Job>();
var applicationRepo = new FileRepository<Application>();

jobRepo.Add(new Job(1, "Frontend Intern", "Punë part-time për student", "IT", "Mitrovicë", "20 orë/javë", 250, 1));
jobRepo.Add(new Job(2, "Marketing Assistant", "Punë për studentë", "Marketing", "Prishtinë", "15 orë/javë", 200, 2));

var menu = new MenuManager(
    new JobService(jobRepo),
    new ApplicationService(applicationRepo, jobRepo)
);

menu.Start();