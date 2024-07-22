using CCPS610_Assignment2.DatabaseContext;
using CCPS610_Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCPS610_Assignment2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ModelContext _context;

        public EmployeeController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Employee/AllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.HrEmployees;
            var employeeModels = employees.Select(emp => new EmployeeModel
            {
                EmployeeId = emp.EmployeeId,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                HireDate = emp.HireDate,
                JobId = emp.JobId,
                Salary = emp.Salary,
                CommissionPct = emp.CommissionPct,
                ManagerId = emp.ManagerId,
                DepartmentId = emp.DepartmentId,
            }).ToList();

            return Json(employeeModels);
        }
    }
}
