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
            //var compmat = Inference.ComparisonMatrix(values, ConfLevel);

            (double, double, double)[,] TFNs =
            {
                {
                    (1, 1, 1), (1, 2, 3), (2, 3, 4),
                    (3, 4, 5), (4, 5, 6), (5, 6, 7),
                    (6, 7, 8), (7, 8, 9), (9, 9, 9)
                },
                {
                    (1, 1, 1), (1.5, 2, 2.5), (2.5, 3, 3.5),
                    (3.5, 4, 4.5), (4.5, 5, 5.5), (5.5, 6, 6.5),
                    (6.5, 7, 7.5), (7.5, 8, 8.5), (9, 9, 9)
                },
                {
                    (1, 1, 1), (2, 2, 2), (3, 3, 3),
                    (4, 4, 4), (5, 5, 5), (6, 6, 6),
                    (7, 7, 7), (8, 8, 8), (9, 9, 9)
                }
            };

            int i;

            (double, double, double)[,] compmat = new (double, double, double)[6, 6];

            for (int j = 0; j <= 5; j++)
                compmat[j, j] = (1.0, 1.0, 1.0);


            for (i = 0; i < 5; i++)
            {
                if (values[i] < 0)
                    compmat[i, i + 1] = TFNs[ConfLevel, -1 - values[i]];
                else if (values[i] > 0)
                    compmat[i, i + 1] = TFNs[ConfLevel, -1 + values[i]].Inverse();
                else
                    compmat[i, i + 1] = (1, 1, 1);
            }

            for (i = 0; i <= 3; i++)
                compmat[i, i + 2] = compmat[i, i + 1].Multiply(compmat[i + 1, i + 2]);

            for (i = 0; i <= 2; i++)
                compmat[i, i + 3] = compmat[i, i + 2].Multiply(compmat[i + 2, i + 3]);

            for (i = 0; i <= 1; i++)
                compmat[i, i + 4] = compmat[i, i + 3].Multiply(compmat[i + 3, i + 4]);

            i = 0;
            compmat[i, i + 5] = compmat[i, i + 4].Multiply(compmat[i + 4, i + 5]);

            for (int r = 1; r <= 5; r++)
                for (int c = 0; c < r; c++)
                    compmat[r, c] = compmat[c, r].Inverse();


            Program.Query.Weights = (new FAHP(compmat)).CriteriaWeights;
            return RedirectToPage("/Result");

        }
    }
}