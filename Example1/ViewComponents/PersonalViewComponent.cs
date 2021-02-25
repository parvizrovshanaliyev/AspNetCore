using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example1.ViewComponents
{
    public class PersonalViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var data = new List<Personal>
            {
                new Personal {Name = "Parviz", Email = "mail1", Notes = "coder1"},
                new Personal {Name = "Parviz2", Email = "mail13", Notes = "coder133"},
                new Personal {Name = "Parviz3", Email = "mail14", Notes = "coder143"},
                new Personal {Name = "Parviz4", Email = "mail12", Notes = "coder13"}
            };
            return View(data);
        }
    }
}
