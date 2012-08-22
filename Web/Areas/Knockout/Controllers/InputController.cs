using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace Web.Areas.Knockout.Controllers
{
    public class InputViewModel
    {
        public string qty { get; set; }
    } 
    public class ResultViewModel
    {
        public int year { get; set; }
        public float day { get; set; }
        public float week { get; set; }
    }

    public class InputController : Controller
    {
        //
        // GET: /Knockout/Input/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Calc(InputViewModel input)
        {
            Thread.Sleep(300); 

            return Json(this.GetResults(), JsonRequestBehavior.AllowGet); //Content(r);
        }

          
        private IQueryable<ResultViewModel>  GetResults()
        {
            var l = new List<ResultViewModel>();
            l.Add(new ResultViewModel { day = 2, week = 3, year = 3 });
            //l.Add(new TaskViewModel { title = "Wire the money to Panama", isDone = false }); 
            return l.Where(x => true).AsQueryable(); 
        }





    }
}
