using AutoMapper;
using CCPS610_Assignment2.DatabaseContext;
using CCPS610_Assignment2.DatabaseContext.Tables;
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
            var jobs = _context.HrJobs.OrderBy(u => u.JobTitle);
            var jobModels = jobs.Select(emp => _mapper.Map<JobModel>(emp)).ToList();

            return Json(jobModels);
        }

        [HttpGet("Job/GetJobDescription/{jobId}")]
        public IActionResult GetJobDescription(string jobId)
        {
            var job = _context.HrJobs.FirstOrDefault(j => j.JobId.ToLower().Trim() == jobId.ToLower());

            if (job == null)
            {
                return NotFound("Job Id not found.");
            }

            var jobModel = _mapper.Map<JobModel>(job);

            return Json(jobModel);
        }

        [HttpGet("Job/Create")]
        public IActionResult Create()
        {
            return View(new JobModel());
        }

        [HttpPost("Job/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobModel jobModel)
        {
            if (!ModelState.IsValid)
            {
                return View(jobModel);
            }

            var hrJob = _mapper.Map<HrJob>(jobModel);

            _context.HrJobs.Add(hrJob);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Job/Edit/{jobId}")]
        public IActionResult Edit(string jobId)
        {
            var job = _context.HrJobs.FirstOrDefault(u => u.JobId == jobId);

            if (job == null)
                return NotFound();

            return View(_mapper.Map<JobModel>(job));
        }

        [HttpPost("Job/Edit/{jobId}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string jobId, JobModel jobModel)
        {
            if (!ModelState.IsValid)
            {
                return View(jobModel);
            }

            var hrJob = _mapper.Map<HrJob>(jobModel);

            _context.HrJobs.Attach(hrJob);
            _context.Entry(hrJob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Job/Delete/{jobId}")]
        public IActionResult Delete(string jobId)
        {
            var job = _context.HrJobs.FirstOrDefault(u => u.JobId == jobId);

            if (job == null)
                return NotFound();

            _context.HrJobs.Remove(job);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
