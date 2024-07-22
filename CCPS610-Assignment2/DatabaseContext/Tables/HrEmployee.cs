using System;
using System.Collections.Generic;

namespace CCPS610_Assignment2.DatabaseContext.Tables
{
    public partial class HrEmployee
    {
        public HrEmployee()
        {
            HrDepartments = new HashSet<HrDepartment>();
            HrJobHistories = new HashSet<HrJobHistory>();
            InverseManager = new HashSet<HrEmployee>();
        }

        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string JobId { get; set; } = null!;
        public decimal? Salary { get; set; }
        public decimal? CommissionPct { get; set; }
        public int? ManagerId { get; set; }
        public byte? DepartmentId { get; set; }

        public virtual HrDepartment? Department { get; set; }
        public virtual HrJob Job { get; set; } = null!;
        public virtual HrEmployee? Manager { get; set; }
        public virtual ICollection<HrDepartment> HrDepartments { get; set; }
        public virtual ICollection<HrJobHistory> HrJobHistories { get; set; }
        public virtual ICollection<HrEmployee> InverseManager { get; set; }
    }
}
