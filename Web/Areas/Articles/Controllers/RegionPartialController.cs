using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Articles.Controllers
{
    public class RegionPartialController : Controller
    {
        //
        // GET: /Articles/ArticleRegionPartial/

        public ActionResult Index()
        {
            return View();
        }



        //[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult Post(string name, string email)
        {
            var r = new List<RegionPartialModel>();
            r.Add(new RegionPartialModel { Name = "Hawaii", IsInCategory = true, IsPrimary = false });
            r.Add(new RegionPartialModel { Name = "Valley", IsInCategory = true, IsPrimary = false });
            r.Add(new RegionPartialModel { Name = "Georgia", IsInCategory = true, IsPrimary = false });
            r.Add(new RegionPartialModel { Name = "Ohio", IsInCategory = true, IsPrimary = false });
             
            //render the new customer's listitem and return the result
            return PartialView("RegionPartial", r);
        }



    }

    public class RegionPartialModel
    {
        public string Name { get; set; }
        public bool IsInCategory { get; set; }
        public bool IsPrimary { get; set; }
    }

}
