using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewFAHP.App.Pages
{
    public class ResultModel : PageModel
    {
        [BindProperty] public List<string> Criteria { get; set; }
        [BindProperty] public double StdDev { get; set; }
        [BindProperty] public string ConfLevel { get; set; }

        public ResultModel()
        {
            Criteria = new List<string>
            {
                "Teacher-Student ratio", "Male-Female Ratio",
                "Socio-Economic Status", "Location of School",
                "Age of School", "Average Age of Students"
            };

            StdDev = GetStdDev(Program.Query.Weights);
            ConfLevel = new string[] { "Low", "Medium", "High" }[Program.Query.ConfLevel];
        }

        private double GetStdDev(double[] values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                double avg = values.Average();    
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
    }
}