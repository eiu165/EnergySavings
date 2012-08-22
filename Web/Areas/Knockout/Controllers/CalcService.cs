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
            r.annualHours = GetAnnualHours(year, input);
            r.day = 3;
            r.week = 3;
            r.month = 2;
            return r; 
        }


        private static float GetAnnualHours(float years, InputViewModel input)
        {
            var totalkw = input.kw * input.qty;
            float hours = input.cost / (years * totalkw * input.rate);
            return hours;
        }

    }
}