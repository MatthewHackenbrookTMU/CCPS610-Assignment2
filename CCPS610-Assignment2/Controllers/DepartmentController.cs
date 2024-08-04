using AutoMapper;
using CCPS610_Assignment2.DatabaseContext;
using CCPS610_Assignment2.DatabaseContext.Tables;
using CCPS610_Assignment2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CCPS610_Assignment2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ModelContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(ModelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Department/AllDeparments")]
        public IActionResult GetAllDepartments()
        {
            var departments = _context.HrDepartments.OrderByDescending(u => u.DepartmentId);
            var departmentModels = departments.Select(dept => _mapper.Map<DepartmentModel>(dept)).ToList();
            return Json(departmentModels);
        }
    }
}
