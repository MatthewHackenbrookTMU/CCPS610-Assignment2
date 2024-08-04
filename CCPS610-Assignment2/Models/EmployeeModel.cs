using CCPS610_Assignment2.DatabaseContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CCPS610_Assignment2.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
        
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Today;

        [Required]
        [Display(Name = "Job")]
        public string JobId { get; set; } = null!;
        public decimal? Salary { get; set; }

        [Display(Name = "Commission (%)")]
        public decimal? CommissionPct { get; set; }

        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
    }
}
