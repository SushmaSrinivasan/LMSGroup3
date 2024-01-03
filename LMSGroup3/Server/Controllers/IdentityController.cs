using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMSGroup3.Server.Controllers
{
    [Authorize]
    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SuperUser()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }
    }
}
