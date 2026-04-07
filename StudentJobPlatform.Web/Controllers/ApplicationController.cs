using Microsoft.AspNetCore.Mvc;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.Web.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationService _applicationService;
        private readonly JobService _jobService;

        public ApplicationController(ApplicationService applicationService, JobService jobService)
        {
            _applicationService = applicationService;
            _jobService = jobService;
        }

        [HttpGet]
        public IActionResult Apply(int jobId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                TempData["Error"] = "Duhet të bësh login.";
                return RedirectToAction("Login", "Auth");
            }

            var job = _jobService.GetJobById(jobId);

            if (job == null)
            {
                TempData["Error"] = "Job nuk ekziston.";
                return RedirectToAction("Dashboard", "Auth");
            }

            bool success = _applicationService.ApplyToJob(userId.Value, jobId, out string message);

            if (success)
                TempData["Success"] = message;
            else
                TempData["Error"] = message;

            return RedirectToAction("Dashboard", "Auth");
        }
    }
}