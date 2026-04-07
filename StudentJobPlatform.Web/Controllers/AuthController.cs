using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentJobPlatform.Models;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        private readonly JobService _jobService;
        private readonly ApplicationService _applicationService;

        public AuthController(
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

        private bool IsStudent() =>
            GetRole()?.Equals(Constants.StudentRole, StringComparison.OrdinalIgnoreCase) == true;

        private bool IsEmployer() =>
            GetRole()?.Equals(Constants.EmployerRole, StringComparison.OrdinalIgnoreCase) == true;

        private bool IsAdmin() =>
            GetRole()?.Equals(Constants.AdminRole, StringComparison.OrdinalIgnoreCase) == true;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var user = _authService.Login(email, password);

                if (user == null)
                {
                    ViewBag.Error = "Invalid email or password.";
                    return View();
                }

                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserRole", user.Role);

                if (user.Role.Equals(Constants.AdminRole, StringComparison.OrdinalIgnoreCase))
                    return RedirectToAction("Dashboard", "Admin");

                if (user.Role.Equals(Constants.EmployerRole, StringComparison.OrdinalIgnoreCase))
                    return RedirectToAction("EmployerDashboard");

                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                ViewBag.Error = "Ndodhi një gabim gjatë login.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string email, string password, string role)
        {
            try
            {
                _authService.Register(name, email, password, role);
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Dashboard(string? search, string? category, string? sort)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login");

            try
            {
                if (IsAdmin())
                    return RedirectToAction("Dashboard", "Admin");

                if (IsEmployer())
                    return RedirectToAction("EmployerDashboard");

                List<Job> jobs = _jobService.GetAllJobs();

                if (!string.IsNullOrWhiteSpace(search))
                    jobs = _jobService.SearchJobs(search);

                if (!string.IsNullOrWhiteSpace(category))
                {
                    jobs = jobs
                        .Where(j => j.Category != null &&
                                    j.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                jobs = sort switch
                {
                    "title" => jobs.OrderBy(j => j.Title).ToList(),
                    "salaryAsc" => jobs.OrderBy(j => j.Salary).ToList(),
                    "salaryDesc" => jobs.OrderByDescending(j => j.Salary).ToList(),
                    _ => jobs
                };

                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.Search = search ?? "";
                ViewBag.Category = category ?? "";
                ViewBag.Sort = sort ?? "";

                return View(jobs);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Gabim në dashboard.";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult MyApplications()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login");

            try
            {
                if (!IsStudent())
                    return RedirectToAction("Dashboard");

                int studentId = HttpContext.Session.GetInt32("UserId") ?? 0;
                var applications = _applicationService.GetApplicationsByStudent(studentId);

                return View(applications);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Gabim gjatë aplikimeve.";
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login");

            try
            {
                if (!IsStudent())
                    return RedirectToAction("Dashboard");

                int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
                var user = _authService.GetById(userId);

                if (user == null)
                {
                    TempData["Error"] = "User nuk u gjet.";
                    return RedirectToAction("Dashboard");
                }

                return View(user);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Gabim në profil.";
                return RedirectToAction("Dashboard");
            }
        }

        [HttpPost]
        public IActionResult Profile(string major, string skills, string location, string availability)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login");

            try
            {
                if (!IsStudent())
                    return RedirectToAction("Dashboard");

                int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
                bool success = _authService.UpdateProfile(userId, major, skills, location, availability);

                if (!success)
                {
                    TempData["Error"] = "Profili nuk u përditësua.";
                    return RedirectToAction("Profile");
                }

                TempData["Success"] = "Profile updated.";
                return RedirectToAction("Profile");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Gabim gjatë update.";
                return RedirectToAction("Profile");
            }
        }

        [HttpGet]
        public IActionResult Recommended()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login");

            try
            {
                if (!IsStudent())
                    return RedirectToAction("Dashboard");

                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                return View(new List<Job>());
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim.";
                return RedirectToAction("Dashboard");
            }
        }

        [HttpPost]
        public IActionResult Recommended(string major, string skills, string availability)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login");

            try
            {
                if (!IsStudent())
                    return RedirectToAction("Dashboard");

                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.Major = major ?? "";
                ViewBag.Skills = skills ?? "";
                ViewBag.Availability = availability ?? "";

                var jobs = _jobService.GetRecommendedJobs(major ?? "", skills ?? "", availability ?? "");
                return View(jobs);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Ndodhi një gabim gjatë rekomandimeve.";
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        public IActionResult EmployerDashboard()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login");

            try
            {
                if (!IsEmployer())
                    return RedirectToAction("Dashboard");

                int employerId = HttpContext.Session.GetInt32("UserId") ?? 0;
                var jobs = _jobService.GetJobsByEmployer(employerId);

                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                return View(jobs);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                TempData["Error"] = "Gabim në employer dashboard.";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}