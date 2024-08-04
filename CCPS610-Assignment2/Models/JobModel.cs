using System.ComponentModel.DataAnnotations;

namespace CCPS610_Assignment2.Models
{
    public class JobModel
    {
        [Display(Name = "Job ID")]
        public string JobId { get; set; } = null!;

        [Display(Name = "Title")]
        public string JobTitle { get; set; } = null!;

        [Display(Name = "Minimum Salary")]
        public int? MinSalary { get; set; }

        [Display(Name = "Maximum Salary")]
        public int? MaxSalary { get; set; }
    }
}
