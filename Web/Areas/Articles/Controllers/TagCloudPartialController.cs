using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Articles.Controllers
{
    public class TagCloudPartialController : Controller
    {
        //
        // GET: /Articles/TagCloudPartial/

        public ActionResult Index()
        {
            return View();
        }



        //[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult Post(string name, string email)
        {
            var r = new List<TagCloudPartialModel>();
            r.Add(new TagCloudPartialModel { Name = "Health", IsInTag = true, });
            r.Add(new TagCloudPartialModel { Name = "Running", IsInTag = true  });
            r.Add(new TagCloudPartialModel { Name = "Seniors", IsInTag = true  });
            r.Add(new TagCloudPartialModel { Name = "Sun", IsInTag = false  });

            //render the new customer's listitem and return the result
            return PartialView("TagCloudPartial", r);
        }



    }
    public class TagCloudPartialModel
    {
        public string Name { get; set; }
        public bool IsInTag { get; set; } 
    }

}
