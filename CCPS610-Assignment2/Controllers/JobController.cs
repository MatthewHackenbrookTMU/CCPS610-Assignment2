using CCPS610_Assignment2.DatabaseContext;
using CCPS610_Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCPS610_Assignment2.Controllers
{
    public class JobController : Controller
    {
        private readonly ModelContext _context;

        public JobController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Job/AllJobs")]
        public IActionResult GetAllJobs()
        {
            var jobs = _context.HrJobs;
            var jobModels = jobs.Select(job => new JobModel
                {
                    JobId = job.JobId,
                    JobTitle = job.JobTitle,
                    MinSalary = job.MinSalary,
                    MaxSalary = job.MaxSalary
                }).ToList();

            return Json(jobModels);
        }
    }
}
