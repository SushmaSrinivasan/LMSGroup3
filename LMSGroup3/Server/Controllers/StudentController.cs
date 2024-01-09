using Microsoft.AspNetCore.Mvc;

namespace LMSGroup3.Server.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
