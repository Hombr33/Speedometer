using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class PainterUpdater2 : BaseThread
    {

        private Graphics g = null;
        private BasicForm f = null;
        private GearChanger gc = null;
        private System.Windows.Forms.Label l = null;

        public PainterUpdater2(BasicForm f, GearChanger gc)
        {
            g = f.CreateGraphics();
            this.f = f;
            this.gc = gc;
        }


        public override void RunThread()
        {
            while (true)
            {
                if (gc.isChange())
                {
                    l = f.getGear();
                    Action action_update_l = () => l.Text = gc.getGear().ToString();
                    f.Invoke(action_update_l);
                    gc.setChange(false);
                }
            }
        }
    }
}
