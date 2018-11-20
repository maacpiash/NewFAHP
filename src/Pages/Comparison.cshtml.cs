using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewFAHP.Lib;

using static System.Convert;

namespace NewFAHP.App.Pages
{
    public class ComparisonModel : PageModel
    {
        [BindProperty]
        public string MF_TS { get; set; }
        [BindProperty]
        public string MF_AA { get; set; }
        [BindProperty]
        public string MF_LA { get; set; }
        [BindProperty]
        public string MF_SA { get; set; }
        [BindProperty]
        public string MF_SE { get; set; }

        [BindProperty]
        public int ConfLevel { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            int[] values = { ToInt32(MF_TS), ToInt32(MF_AA), ToInt32(MF_LA), ToInt32(MF_SA), ToInt32(MF_SE) };
            Program.Query.ConfLevel = ConfLevel;
            var compmat = Inference.ComparisonMatrix(values, ConfLevel);
            Program.Query.CompMat = compmat;
            Program.Query.Weights = new FAHP(compmat).CriteriaWeights;
            return RedirectToPage("/Result");
        }
    }
}