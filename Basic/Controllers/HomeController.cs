using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Controllers
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

        public IActionResult Authenticate()
        {
            var basicClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Parviz"),
                new Claim(ClaimTypes.Email,"parvizra@code"),
                new Claim("Parviz.Says","fuck off")
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Parviz RA"),
                new Claim("DriverLicense","AA")
            };

            var basicIdentity = 
                new ClaimsIdentity(basicClaims, "Basic Identity");
            var licenseIdentity = 
                new ClaimsIdentity(basicClaims, "Government");

            var userPrincipal = 
                new ClaimsPrincipal(new[] { basicIdentity, licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}