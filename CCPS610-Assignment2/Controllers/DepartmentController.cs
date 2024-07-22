using Microsoft.AspNetCore.Mvc;

namespace CCPS610_Assignment2.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
