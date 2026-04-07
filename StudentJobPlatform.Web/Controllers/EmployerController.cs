using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.Web.Controllers
{
    public class EmployerController : Controller
    {
        private readonly JobService _jobService;
        private readonly ApplicationService _applicationService;

        public EmployerController(JobService jobService, ApplicationService applicationService)
        {
            _jobService = jobService;
            _applicationService = applicationService;
        }

        private bool IsLoggedIn()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }

        private string? GetRole()
        {
            return HttpContext.Session.GetString("UserRole");
        }

        private bool IsEmployer()
        {
            return GetRole()?.Equals(Constants.EmployerRole, StringComparison.OrdinalIgnoreCase) == true;
        }

        private int GetCurrentEmployerId()
        {
            return HttpContext.Session.GetInt32("UserId") ?? 0;
        }

        private string? ValidateJobInput(string title, string company, string description, string category, string location, string workingHours, decimal salary)
        {
            if (string.IsNullOrWhiteSpace(title))
                return "Title është i detyrueshëm.";

            if (string.IsNullOrWhiteSpace(company))
                return "Company është i detyrueshëm.";

            if (string.IsNullOrWhiteSpace(description))
                return "Description është i detyrueshëm.";

            if (string.IsNullOrWhiteSpace(category))
                return "Category është i detyrueshëm.";

            if (string.IsNullOrWhiteSpace(location))
                return "Location është i detyrueshëm.";

            if (string.IsNullOrWhiteSpace(workingHours))
                return "Working Hours janë të detyrueshme.";

            if (salary <= 0)
                return "Salary duhet të jetë më e madhe se 0.";

            return null;
        }

        private Job? GetEmployerOwnedJob(int jobId, int employerId)
        {
            var job = _jobService.GetJobById(jobId);

            if (job == null)
                return null;

            if (job.EmployerId != employerId)
                return null;

            return job;
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsEmployer())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë hapjes së faqes.";
                return RedirectToAction("EmployerDashboard", "Auth");
            }
        }

        [HttpPost]
        public IActionResult AddJob(string title, string company, string description, string category, string location, string workingHours, decimal salary)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsEmployer())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                var validationError = ValidateJobInput(title, company, description, category, location, workingHours, salary);

                if (validationError != null)
                {
                    ViewBag.Error = validationError;
                    return View();
                }

                int employerId = GetCurrentEmployerId();
                int newId = _jobService.GetNextJobId();

                var job = new Job(newId, title, company, description, category, location, workingHours, salary, employerId);

                bool success = _jobService.AddJob(job);

                if (!success)
                {
                    ViewBag.Error = "Job nuk u shtua.";
                    return View();
                }

                TempData["Success"] = "Job u shtua me sukses.";
                return RedirectToAction("EmployerDashboard", "Auth");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                ViewBag.Error = "Ndodhi një gabim gjatë shtimit të job-it.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditJob(int id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsEmployer())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                if (id <= 0)
                {
                    TempData["Error"] = "Job ID nuk është valid.";
                    return RedirectToAction("EmployerDashboard", "Auth");
                }

                int employerId = GetCurrentEmployerId();
                var job = GetEmployerOwnedJob(id, employerId);

                if (job == null)
                {
                    TempData["Error"] = "Job nuk u gjet ose nuk ke të drejtë ta editosh.";
                    return RedirectToAction("EmployerDashboard", "Auth");
                }

                return View(job);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë hapjes së job-it.";
                return RedirectToAction("EmployerDashboard", "Auth");
            }
        }

        [HttpPost]
        public IActionResult EditJob(int id, string title, string company, string description, string category, string location, string workingHours, decimal salary)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsEmployer())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                if (id <= 0)
                {
                    TempData["Error"] = "Job ID nuk është valid.";
                    return RedirectToAction("EmployerDashboard", "Auth");
                }

                int employerId = GetCurrentEmployerId();
                var existingJob = GetEmployerOwnedJob(id, employerId);

                if (existingJob == null)
                {
                    TempData["Error"] = "Job nuk u gjet ose nuk ke të drejtë ta editosh.";
                    return RedirectToAction("EmployerDashboard", "Auth");
                }

                var validationError = ValidateJobInput(title, company, description, category, location, workingHours, salary);

                if (validationError != null)
                {
                    ViewBag.Error = validationError;
                    return View(existingJob);
                }

                var updatedJob = new Job(id, title, company, description, category, location, workingHours, salary, employerId);

                bool success = _jobService.UpdateJob(updatedJob);

                if (!success)
                {
                    ViewBag.Error = "Job nuk u përditësua.";
                    return View(updatedJob);
                }

                TempData["Success"] = "Job u përditësua me sukses.";
                return RedirectToAction("EmployerDashboard", "Auth");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë përditësimit të job-it.";
                return RedirectToAction("EmployerDashboard", "Auth");
            }
        }

        [HttpGet]
        public IActionResult DeleteJob(int id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsEmployer())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                if (id <= 0)
                {
                    TempData["Error"] = "Job ID nuk është valid.";
                    return RedirectToAction("EmployerDashboard", "Auth");
                }

                int employerId = GetCurrentEmployerId();
                var job = GetEmployerOwnedJob(id, employerId);

                if (job == null)
                {
                    TempData["Error"] = "Job nuk u gjet ose nuk ke të drejtë ta fshish.";
                    return RedirectToAction("EmployerDashboard", "Auth");
                }

                bool success = _jobService.DeleteJob(id);

                if (success)
                    TempData["Success"] = "Job u fshi me sukses.";
                else
                    TempData["Error"] = "Job nuk u fshi.";

                return RedirectToAction("EmployerDashboard", "Auth");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë fshirjes së job-it.";
                return RedirectToAction("EmployerDashboard", "Auth");
            }
        }

        [HttpGet]
        public IActionResult Applications()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsEmployer())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                int employerId = GetCurrentEmployerId();

                var myJobs = _jobService.GetJobsByEmployer(employerId);
                var myJobIds = myJobs.Select(j => j.Id).ToList();

                var applications = _applicationService
                    .GetAllApplications()
                    .Where(a => myJobIds.Contains(a.JobId))
                    .ToList();

                return View(applications);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë ngarkimit të aplikimeve.";
                return RedirectToAction("EmployerDashboard", "Auth");
            }
        }

        [HttpPost]
        public IActionResult ChangeApplicationStatus(int applicationId, string status)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsEmployer())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                if (applicationId <= 0)
                {
                    TempData["Error"] = "Application ID nuk është valid.";
                    return RedirectToAction("Applications");
                }

                if (string.IsNullOrWhiteSpace(status))
                {
                    TempData["Error"] = "Statusi nuk është valid.";
                    return RedirectToAction("Applications");
                }

                int employerId = GetCurrentEmployerId();
                var myJobs = _jobService.GetJobsByEmployer(employerId);
                var myJobIds = myJobs.Select(j => j.Id).ToList();

                var application = _applicationService.GetById(applicationId);

                if (application == null)
                {
                    TempData["Error"] = "Aplikimi nuk u gjet.";
                    return RedirectToAction("Applications");
                }

                if (!myJobIds.Contains(application.JobId))
                {
                    TempData["Error"] = "Nuk ke të drejtë ta ndryshosh këtë aplikim.";
                    return RedirectToAction("Applications");
                }

                _applicationService.UpdateApplicationStatus(applicationId, status);
                TempData["Success"] = "Statusi u përditësua me sukses.";

                return RedirectToAction("Applications");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë ndryshimit të statusit.";
                return RedirectToAction("Applications");
            }
        }
    }
}