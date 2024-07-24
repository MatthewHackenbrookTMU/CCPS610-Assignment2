namespace CCPS610_Assignment2.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? ManagerId { get; set; }
        public int? LocationId { get; set; }
    }
}
