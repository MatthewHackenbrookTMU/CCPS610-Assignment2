using System;
using System.Collections.Generic;

namespace CCPS610_Assignment2.DatabaseContext.Tables
{
    public partial class HrDepartment
    {
        public HrDepartment()
        {
            HrEmployees = new HashSet<HrEmployee>();
            HrJobHistories = new HashSet<HrJobHistory>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? ManagerId { get; set; }
        public int? LocationId { get; set; }

        public virtual HrLocation? Location { get; set; }
        public virtual HrEmployee? Manager { get; set; }
        public virtual ICollection<HrEmployee> HrEmployees { get; set; }
        public virtual ICollection<HrJobHistory> HrJobHistories { get; set; }
    }
}
