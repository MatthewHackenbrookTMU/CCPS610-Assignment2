using CCPS610_Assignment2.DatabaseContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCPS610_Assignment2.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Today;
        public string JobId { get; set; } = null!;
        public decimal? Salary { get; set; }
        public decimal? CommissionPct { get; set; }
        public int? ManagerId { get; set; }
        public byte? DepartmentId { get; set; }
    }
}
