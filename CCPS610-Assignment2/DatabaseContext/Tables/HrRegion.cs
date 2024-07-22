using System;
using System.Collections.Generic;

namespace CCPS610_Assignment2.DatabaseContext.Tables
{
    public partial class HrRegion
    {
        public HrRegion()
        {
            HrCountries = new HashSet<HrCountry>();
        }

        public decimal RegionId { get; set; }
        public string? RegionName { get; set; }

        public virtual ICollection<HrCountry> HrCountries { get; set; }
    }
}
