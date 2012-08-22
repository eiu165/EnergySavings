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
        public float qty { get; set; }
        public float kw { get; set; }
        public float rate { get; set; }
        public float cost { get; set; }
        public float weeks { get; set; }
        public float days { get; set; }
        public float hours { get; set; } 
    } 
    public class ResultViewModel
    {
        public float year { get; set; }
        public float annualHours { get; set; }
        public float hours { get; set; }
        public float day { get; set; }
        public float week { get; set; }
        public float month { get; set; }
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
            return Json(this.GetResults(input), JsonRequestBehavior.AllowGet); //Content(r);
        }


        private IQueryable<ResultViewModel> GetResults(InputViewModel input)
        {
            var l = new List<ResultViewModel>();
            l.Add(CalcService.GetResultViewModel(year: 1, input: input));
            l.Add(CalcService.GetResultViewModel(year: 2, input: input));
            l.Add(CalcService.GetResultViewModel(year: 3, input: input));
            l.Add(CalcService.GetResultViewModel(year: 4, input: input));
            l.Add(CalcService.GetResultViewModel(year: 5, input: input));
            return l.Where(x => true).AsQueryable(); 
        }

    }
}
