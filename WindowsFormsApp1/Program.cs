using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Speedometer s = new Speedometer();
            GearChanger gc = new GearChanger();
            Clutch c = new Clutch();
            BasicForm f = new BasicForm(s, gc, c);
            f.MinimumSize = new System.Drawing.Size(500, 500);
            f.MaximumSize = new System.Drawing.Size(500, 500);
            f.MaximizeBox = false;
            f.MinimizeBox = false;
            Application.Run(f);
        }
    }
}
