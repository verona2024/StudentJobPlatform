using System;
using Microsoft.AspNetCore.Mvc;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthService _authService;
        private readonly JobService _jobService;
        private readonly ApplicationService _applicationService;

        public AdminController(
            AuthService authService,
            JobService jobService,
            ApplicationService applicationService)
        {
            _authService = authService;
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

        private bool IsAdmin()
        {
            return GetRole()?.Equals(Constants.AdminRole, StringComparison.OrdinalIgnoreCase) == true;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsAdmin())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.UsersCount = _authService.GetAllUsers().Count;
                ViewBag.JobsCount = _jobService.GetAllJobs().Count;
                ViewBag.ApplicationsCount = _applicationService.GetAllApplications().Count;

                return View();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë hapjes së dashboard-it.";
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpGet]
        public IActionResult Users()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsAdmin())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                var users = _authService.GetAllUsers();
                return View(users);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë ngarkimit të users.";
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        public IActionResult Jobs()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsAdmin())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                var jobs = _jobService.GetAllJobs();
                return View(jobs);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë ngarkimit të jobs.";
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        public IActionResult Applications()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Auth");

            if (!IsAdmin())
                return RedirectToAction("Dashboard", "Auth");

            try
            {
                var applications = _applicationService.GetAllApplications();
                return View(applications);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë ngarkimit të applications.";
                return RedirectToAction("Dashboard");
            }
        }
    }
}