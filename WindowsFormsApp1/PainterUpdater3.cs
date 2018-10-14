using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class PainterUpdater3
    {

        private System.Windows.Forms.Label l = null;
        private System.Windows.Forms.Form f = null;
        public PainterUpdater3(System.Windows.Forms.Label l, System.Windows.Forms.Form f)
        {
            this.l = l;
            this.f = f;
        }

        public static string clutchPressed = "Clutch Pressed";
        public static string accelPressed = "Accelerating...";
        public static string clutchReleased = "Clutch Released";
        public static string ignitionOn = "Engine Started";
        public static string killedEngin = "Engine is dead";
      
        public void RunMessage(string message)
        {
            Action action_update_l = () => l.Text = message;
            f.Invoke(action_update_l);
        }
    }
}
