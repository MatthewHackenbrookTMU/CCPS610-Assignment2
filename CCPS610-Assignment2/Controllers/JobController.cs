using AutoMapper;
using CCPS610_Assignment2.DatabaseContext;
using CCPS610_Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCPS610_Assignment2.Controllers
{
    public class JobController : Controller
    {
        private readonly ModelContext _context;
        private readonly IMapper _mapper;

        public JobController(ModelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Job/AllJobs")]
        public IActionResult GetAllJobs()
        {
            var jobs = _context.HrJobs;
            var jobModels = jobs.Select(emp => _mapper.Map<JobModel>(emp)).ToList();

            return Json(jobModels);
        }

    }
}
