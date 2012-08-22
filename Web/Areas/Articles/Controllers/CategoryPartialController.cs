using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Articles.Controllers
{
    public class CategoryPartialController : Controller
    {
        //
        // GET: /Articles/ArticleCategoryPartial/

        public ActionResult Index()
        {
            return View();
        }
    }

    public class CategoryPartialModel
    {
        public string Name { get; set; }
        public bool IsInCategory { get; set; }
        public bool IsPrimary { get; set; } 
    }
}



