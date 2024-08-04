using AutoMapper;
using CCPS610_Assignment2.DatabaseContext;
using CCPS610_Assignment2.DatabaseContext.Tables;
using CCPS610_Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;

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

        private void Validate(EmployeeModel employeeModel)
        {
            if (_context.HrEmployees.Any(u => u.EmployeeId != employeeModel.EmployeeId && u.Email == employeeModel.Email))
                ModelState.AddModelError("email", "Email must be unique. Please choose a valid email.");

            var phoneNumberRegex = new Regex(@"[^0-9.]");
            if (employeeModel.PhoneNumber != null && phoneNumberRegex.IsMatch(employeeModel.PhoneNumber))
                ModelState.AddModelError("phoneNumber", "Phone number invalid. Please format as 111.111.1111");
        }

        [HttpPost("Employee/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModel employeeModel)
        {
            if (employeeModel.ManagerId <= 0)
                employeeModel.ManagerId = null;
            if (employeeModel.DepartmentId <= 0)
                employeeModel.DepartmentId = null;
            if (employeeModel.PhoneNumber == string.Empty)
                employeeModel.PhoneNumber = null;

            Validate(employeeModel);

            if (!ModelState.IsValid)
            {
                return View(employeeModel);
            }

            var hrEmployee = _mapper.Map<HrEmployee>(employeeModel);

            try
            {
                _context.HireEmployee(hrEmployee);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                TrySortError(ex.Message);
                return View(employeeModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(employeeModel);
            }

            return RedirectToAction(nameof(Index));
        }

        private void TrySortError(string error)
        {
            var errorNoFormat = error.ToLower();
            var noKeyFound = true;
            if (error.Contains("salary"))
            {
                ModelState.AddModelError("salary", ExtractUserFriendlyMessage(error));
                noKeyFound = false;
            }
            if (error.Contains("email"))
            {
                ModelState.AddModelError("email", ExtractUserFriendlyMessage(error));
                noKeyFound = false;
            }

            if (noKeyFound)
                TempData["ErrorMessage"] = ExtractUserFriendlyMessage(error);
        }

        private string ExtractUserFriendlyMessage(string oracleErrorMessage)
        {
            var regex = new Regex(@"ORA-\d{5}: (.+?)(?=ORA-|$)", RegexOptions.Singleline);
            var match = regex.Match(oracleErrorMessage);

            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            return oracleErrorMessage;
        }

        [HttpGet("Employee/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var employee = _context.HrEmployees.FirstOrDefault(u => u.EmployeeId == id);

            if (employee == null)
                return NotFound();

            return View(_mapper.Map<EmployeeModel>(employee));
        }

        [HttpPost("Employee/Edit/{id}")]
        public IActionResult Edit(int id, EmployeeModel employeeModel)
        {
            if (employeeModel.ManagerId <= 0)
                employeeModel.ManagerId = null;
            if (employeeModel.DepartmentId <= 0)
                employeeModel.DepartmentId = null;

            Validate(employeeModel);

            if (!ModelState.IsValid)
            {
                return View(employeeModel);
            }

            var hrEmployee = _mapper.Map<HrEmployee>(employeeModel);

            _context.HrEmployees.Attach(hrEmployee);
            _context.Entry(hrEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            try
            {
                _context.SaveChanges();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                TrySortError(ex.Message);
                return View(employeeModel);
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null && ex.InnerException is OracleException)
                {
                    TrySortError(ex.InnerException.Message);
                    return View(employeeModel);
                }

                TempData["ErrorMessage"] = ex.Message;
                return View(employeeModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Employee/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _context.HrEmployees.FirstOrDefault(u => u.EmployeeId == id);

            if (employee == null)
                return NotFound();

            _context.HrEmployees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Employee/AllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.HrEmployees.OrderByDescending(u => u.EmployeeId);
            var employeeModels = employees.Select(emp => _mapper.Map<EmployeeModel>(emp)).ToList();

            return Json(employeeModels);
        }
    }
}
