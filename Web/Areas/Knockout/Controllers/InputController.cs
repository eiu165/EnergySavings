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
        public float annual { get; set; }
        public float hours { get; set; } 
    } 
    public class ResultViewModel
    {
        public double year { get; set; }
        public double annual { get; set; }
        public double weekly { get; set; }
        public double daily { get; set; }
        public double percent { get; set; }  
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
            l.Add(CalcService.GetResultViewModel(year: 1.0f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 1.5f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 2.0f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 2.5f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 3.0f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 3.5f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 4.0f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 4.5f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 5.0f, input: input));
            l.Add(CalcService.GetResultViewModel(year: 5.5f, input: input));
            return l.Where(x => true).AsQueryable(); 
        }

    }
}
