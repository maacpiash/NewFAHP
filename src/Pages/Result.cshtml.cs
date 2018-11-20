using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewFAHP.App.Pages
{
    public class ResultModel : PageModel
    {
        [BindProperty]
        public double TSR { get; set; }

        [BindProperty]
        public double MFR { get; set; }

        [BindProperty]
        public double SES { get; set; }

        [BindProperty]
        public double DIST { get; set; }

        [BindProperty]
        public double AS { get; set; }

        [BindProperty]
        public double ADS { get; set; }

        public ResultModel()
        {
            TSR = Program.Query.Weights[0];
            MFR = Program.Query.Weights[1];
            SES = Program.Query.Weights[2];
            DIST = Program.Query.Weights[3];
            AS = Program.Query.Weights[4];
            ADS = Program.Query.Weights[5];
        }


    }
}