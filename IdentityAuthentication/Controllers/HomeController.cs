using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(string email, string password)
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register(string email, string password)
        {
            return View();
        }
    }
}