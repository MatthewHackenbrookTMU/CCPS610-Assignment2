using System;
using System.Collections.Generic;

namespace CCPS610_Assignment2.DatabaseContext.Tables
{
    public partial class HrJobGrade
    {
        public string? GradeLevel { get; set; }
        public decimal? LowestSal { get; set; }
        public decimal? HighestSal { get; set; }
    }
}
