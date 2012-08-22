using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Articles.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Articles/Home/

        public ActionResult Index(string articleUrl)
        {
            ViewBag.HasAdminPanel = true;
            return View();
        }

    }
}
