using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.Tests
{
    [TestClass]
    public class ApplicationServiceTests
    {
        [TestMethod]
        public void ApplyToJob_ValidApplication_ReturnsTrue()
        {
            var jobRepo = new InMemoryRepository<Job>();
            var appRepo = new InMemoryRepository<Application>();

            var jobService = new JobService(jobRepo);
            var applicationService = new ApplicationService(appRepo, jobRepo);

            jobService.AddJob(new Job(1, "Developer", "Company", "Desc", "IT", "Prishtine", "Full-time", 500, 1));

            string message;
            var result = applicationService.ApplyToJob(1, 1, out message);

            Assert.IsTrue(result);
            Assert.AreEqual("Aplikimi u krye me sukses!", message);
            Assert.AreEqual(1, applicationService.GetAllApplications().Count);
        }

        [TestMethod]
        public void ApplyToJob_SameJobTwice_ReturnsFalse()
        {
            var jobRepo = new InMemoryRepository<Job>();
            var appRepo = new InMemoryRepository<Application>();

            var jobService = new JobService(jobRepo);
            var applicationService = new ApplicationService(appRepo, jobRepo);

            jobService.AddJob(new Job(1, "Developer", "Company", "Desc", "IT", "Prishtine", "Full-time", 500, 1));

            string message1;
            applicationService.ApplyToJob(1, 1, out message1);

            string message2;
            var result = applicationService.ApplyToJob(1, 1, out message2);

            Assert.IsFalse(result);
            Assert.AreEqual("Ke aplikuar tashmë në këtë punë.", message2);
        }

        [TestMethod]
        public void ApplyToJob_InvalidStudentId_ReturnsFalse()
        {
            var jobRepo = new InMemoryRepository<Job>();
            var appRepo = new InMemoryRepository<Application>();

            var jobService = new JobService(jobRepo);
            var applicationService = new ApplicationService(appRepo, jobRepo);

            jobService.AddJob(new Job(1, "Developer", "Company", "Desc", "IT", "Prishtine", "Full-time", 500, 1));

            string message;
            var result = applicationService.ApplyToJob(0, 1, out message);

            Assert.IsFalse(result);
            Assert.AreEqual("Student ID nuk është valid.", message);
        }

        [TestMethod]
        public void ApplyToJob_InvalidJobId_ReturnsFalse()
        {
            var jobRepo = new InMemoryRepository<Job>();
            var appRepo = new InMemoryRepository<Application>();

            var applicationService = new ApplicationService(appRepo, jobRepo);

            string message;
            var result = applicationService.ApplyToJob(1, 0, out message);

            Assert.IsFalse(result);
            Assert.AreEqual("Job ID nuk është valid.", message);
        }

        [TestMethod]
        public void ApplyToJob_JobDoesNotExist_ReturnsFalse()
        {
            var jobRepo = new InMemoryRepository<Job>();
            var appRepo = new InMemoryRepository<Application>();

            var applicationService = new ApplicationService(appRepo, jobRepo);

            string message;
            var result = applicationService.ApplyToJob(1, 999, out message);

            Assert.IsFalse(result);
            Assert.AreEqual("Job nuk ekziston.", message);
        }

        [TestMethod]
        public void HasUserAppliedToJob_WhenApplicationExists_ReturnsTrue()
        {
            var jobRepo = new InMemoryRepository<Job>();
            var appRepo = new InMemoryRepository<Application>();

            var jobService = new JobService(jobRepo);
            var applicationService = new ApplicationService(appRepo, jobRepo);

            jobService.AddJob(new Job(1, "Developer", "Company", "Desc", "IT", "Prishtine", "Full-time", 500, 1));

            string message;
            applicationService.ApplyToJob(1, 1, out message);

            var result = applicationService.HasUserAppliedToJob(1, 1);

            Assert.IsTrue(result);
        }
    }
}