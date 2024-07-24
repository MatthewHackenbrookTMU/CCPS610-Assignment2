using System;
using System.Collections.Generic;

namespace CCPS610_Assignment2.DatabaseContext.Tables
{
    public partial class HrLocation
    {
        public HrLocation()
        {
            HrDepartments = new HashSet<HrDepartment>();
        }

        public int LocationId { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string City { get; set; } = null!;
        public string? StateProvince { get; set; }
        public string? CountryId { get; set; }

        public virtual HrCountry? Country { get; set; }
        public virtual ICollection<HrDepartment> HrDepartments { get; set; }
    }
}
