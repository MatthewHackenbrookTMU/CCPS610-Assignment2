namespace CCPS610_Assignment2.Models
{
    public class JobModel
    {
        public string JobId { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }
    }
}
