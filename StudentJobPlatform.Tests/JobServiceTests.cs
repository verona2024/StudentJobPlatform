using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using StudentJobPlatform.Data;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;
using System.Linq;

namespace StudentJobPlatform.Tests
{
    [TestClass]
    public class JobServiceTests
    {
        [TestMethod]
        public void AddJob_ValidJob_ReturnsTrue()
        {
            var repo = new InMemoryRepository<Job>();
            var service = new JobService(repo);

            var job = new Job(
                1,
                "Software Developer",
                "Tech Company",
                "Develop web applications",
                "IT",
                "Prishtine",
                "Full-time",
                500,
                1
            );

            var result = service.AddJob(job);

            Assert.IsTrue(result);
            Assert.AreEqual(1, service.GetAllJobs().Count);
        }

        [TestMethod]
        public void SortBySalaryAscending_ReturnsOrderedJobs()
        {
            var repo = new InMemoryRepository<Job>();
            var service = new JobService(repo);

            service.AddJob(new Job(1, "Job A", "Comp A", "Desc", "IT", "Prishtine", "Full-time", 300, 1));
            service.AddJob(new Job(2, "Job B", "Comp B", "Desc", "IT", "Prishtine", "Full-time", 100, 1));
            service.AddJob(new Job(3, "Job C", "Comp C", "Desc", "IT", "Prishtine", "Full-time", 200, 1));

            var result = service.SortBySalaryAscending();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(100, result[0].Salary);
            Assert.AreEqual(200, result[1].Salary);
            Assert.AreEqual(300, result[2].Salary);
        }

        [TestMethod]
        public void FilterJobsByLocation_ReturnsCorrectJobs()
        {
            var repo = new InMemoryRepository<Job>();
            var service = new JobService(repo);

            service.AddJob(new Job(1, "Job A", "Comp A", "Desc", "IT", "Prishtine", "Full-time", 300, 1));
            service.AddJob(new Job(2, "Job B", "Comp B", "Desc", "IT", "Tirane", "Full-time", 400, 1));

            var result = service.FilterJobsByLocation("Prishtine");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Prishtine", result.First().Location);
        }
    }
}