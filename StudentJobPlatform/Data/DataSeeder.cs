using StudentJobPlatform.Models;

namespace StudentJobPlatform.Data
{
    public static class DataSeeder
    {
        public static void SeedJobs(IRepository<Job> jobRepo)
        {
            if (!jobRepo.GetAll().Any())
            {
                jobRepo.Add(new Job(1, "Frontend Intern", "Punë part-time për student", "IT", "Mitrovicë", "20 orë/javë", 250, 1));
                jobRepo.Add(new Job(2, "Marketing Assistant", "Punë për studentë", "Marketing", "Prishtinë", "15 orë/javë", 200, 2));
                jobRepo.Save();
            }
        }
    }
}
