using System;
using System.Windows.Forms;
using WindowsFAHP.GUI.Views;

namespace WindowsFAHP.GUI
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}