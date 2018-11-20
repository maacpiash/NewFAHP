using System;
using System.Collections.Generic;
using System.Text;

namespace NewFAHP.Lib
{
    public class Query
    {
        #region Properties
        public int Class { get; set; }
        public double Social { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        public string Division { get; set; }
        public string District { get; set; }
        public string Thana { get; set; }
        public string Union_Ward { get; set; }
        public double SES { get; set; }
        private string _occupation;
        public string Occupation { get => _occupation; set => _occupation = Occupations.Contains(value) ? value : "Other"; }
        public double[] Weights { get; set; }
        #endregion

        private static List<string> occupations;
        public static List<string> Occupations => occupations ?? new List<string>()
        {
            "Worker", "Fisherman", "Tati", "Kamar/Kumar",
            "Cultivation", "Expatriate", "Small business",
            "Govt. job", "Private job", "Teacher",
            "Lawyer", "Doctor", "Engineer", "Businessman"
        };

        public void SetLocation(string div, string dist, string thana, string UW)
        {
            Division = div;
            District = dist;
            Thana = thana;
            Union_Ward = UW;

        }
        
    }


}
