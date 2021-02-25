using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Example1.Models;

namespace Example1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();

            }
            return View();
        }

    }

}
