using Microsoft.AspNetCore.Mvc;

namespace PruebaCoderlandBack.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
