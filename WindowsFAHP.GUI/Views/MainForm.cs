using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFAHP.GUI.Views
{
    public class MainForm : Form
    {
        public MainForm()
        {
            List<Control> MyControls = new List<Control>();
            int loc;
            string[] Labels = {"Fuzzy AHP", "TOPSIS", "Best-Worst Method", "Improved FAHP"};
            foreach (var i in Enumerable.Range(1, 4))
            {
                loc = i * 50;
                MyControls.Add(new Button()
                {
                    Location = new Point(50, loc),
                    Size = new Size(75, 35),
                    Text = Labels[i - 1]
                });
            }
            
            Controls.AddRange(MyControls.ToArray());
                
        }
    }
}