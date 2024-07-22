using AutoMapper;
using CCPS610_Assignment2.DatabaseContext;
using CCPS610_Assignment2.DatabaseContext.Tables;
using CCPS610_Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCPS610_Assignment2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ModelContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(ModelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Employee/Create")]
        public IActionResult Create()
        {
            return View(new EmployeeModel());
        }

        [HttpPost("Employee/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeModel);
            }

            var hrEmployee = _mapper.Map<HrEmployee>(employeeModel);
            _context.HireEmployee(hrEmployee);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Employee/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var employee = _context.HrEmployees.FirstOrDefault(u => u.EmployeeId == id);

            if (employee == null)
                return NotFound();

            return View(_mapper.Map<EmployeeModel>(employee));
        }

        [HttpGet("Employee/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(0);
        }

        [HttpGet("Employee/AllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.HrEmployees;
            var employeeModels = employees.Select(emp => _mapper.Map<EmployeeModel>(emp)).ToList();

            return Json(employeeModels);
        }
    }
}
