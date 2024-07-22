using System;
using System.Collections.Generic;

namespace CCPS610_Assignment2.DatabaseContext.Tables
{
    public partial class HrCountry
    {
        public HrCountry()
        {
            HrLocations = new HashSet<HrLocation>();
        }

        public string CountryId { get; set; } = null!;
        public string? CountryName { get; set; }
        public decimal? RegionId { get; set; }

        public virtual HrRegion? Region { get; set; }
        public virtual ICollection<HrLocation> HrLocations { get; set; }
    }
}
