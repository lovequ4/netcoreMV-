using Microsoft.AspNetCore.Mvc;

namespace examMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
