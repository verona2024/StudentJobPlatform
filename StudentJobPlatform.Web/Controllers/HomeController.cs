using Microsoft.AspNetCore.Mvc;
using StudentJobPlatform.Services;

namespace StudentJobPlatform.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobService _jobService;

        public HomeController(JobService jobService)
        {
            _jobService = jobService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category(string category)
        {
            var jobs = _jobService.FilterJobsByCategory(category);
            ViewBag.Category = category;
            return View(jobs);
        }
    }
}