using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Articles.Controllers
{
    public class HistoryPartialController : Controller
    {
        //
        // GET: /Articles/ArticleHistoryPartial/

        public ActionResult Index()
        {
            return View();
        }

    }
    public class HistoryPartialModel
    {
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Content { get; set; } 
    }
}
