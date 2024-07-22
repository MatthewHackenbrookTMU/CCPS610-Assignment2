using System;
using System.Collections.Generic;

namespace CCPS610_Assignment2.DatabaseContext.Tables
{
    public partial class HrJob
    {
        public HrJob()
        {
            HrEmployees = new HashSet<HrEmployee>();
            HrJobHistories = new HashSet<HrJobHistory>();
        }

        public string JobId { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }

        public virtual ICollection<HrEmployee> HrEmployees { get; set; }
        public virtual ICollection<HrJobHistory> HrJobHistories { get; set; }
    }
}
