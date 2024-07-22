using System;
using System.Collections.Generic;

namespace CCPS610_Assignment2.DatabaseContext.Tables
{
    public partial class HrJobHistory
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobId { get; set; } = null!;
        public byte? DepartmentId { get; set; }

        public virtual HrDepartment? Department { get; set; }
        public virtual HrEmployee Employee { get; set; } = null!;
        public virtual HrJob Job { get; set; } = null!;
    }
}
