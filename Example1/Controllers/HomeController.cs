using Microsoft.AspNetCore.Mvc;

namespace Example1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
