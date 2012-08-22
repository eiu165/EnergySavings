using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Knockout.Controllers
{
    public class CalcService
    {
        public static ResultViewModel GetResultViewModel(float year, InputViewModel input)
        {
            var r = new ResultViewModel();
            r.year = year; 
            var hoursPerYear = input.weeks*input.days*input.hours;
            var annual = Getannual(year, input);
            r.annual = Math.Round(annual, 0);
            r.weekly = Math.Round(annual / input.weeks, 0);
            r.daily = Math.Round(r.weekly / input.days, 2);
            r.percent = Math.Round((annual * 100) / hoursPerYear, 2);
            return r; 
        }


        private static float Getannual(float years, InputViewModel input)
        {
            var totalkw = input.kw * input.qty;
            float annual = input.cost / (years * totalkw * input.rate);
            return annual;
        }

    }
}