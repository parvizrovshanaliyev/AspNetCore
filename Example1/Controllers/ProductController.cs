using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example1.Models;

namespace Example1.Controllers
{
    public class ProductController : Controller
    {

        #region ViewResult

        //public ViewResult Index()
        //{
        //    return View();
        //}

        #endregion
        #region PartialViewResult

        //public PartialViewResult Index()
        //{
        //    return PartialView();
        //}

        #endregion
        #region JsonResult

        //public JsonResult Index()
        //{
        //    return Json(new Product{Id = 1,Name = "iphone",Quantity = 100});
        //}

        #endregion
        #region EmptyResult

        //public EmptyResult Index()
        //{
        //    return new EmptyResult();
        //}

        #endregion
        #region ContentResult

        //public ContentResult Index()
        //{
        //    return Content("hello world");
        //}

        #endregion
        #region ActionResult

        public ActionResult Index() // base action sayilir
        {
            return Content("hello world");
        }

        #endregion
    }

}
