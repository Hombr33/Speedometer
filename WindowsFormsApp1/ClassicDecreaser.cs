using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ClassicDecreaser : BaseThread
    {
        private Speedometer s = null;
        private float speed = 0;

        public ClassicDecreaser(Speedometer s)
        {
            this.s = s;
        }

        public override void RunThread()
        {
            while (true)
            {
                while (!s.getwPressed())
                {
                    this.speed = s.getSpeed();
                    try
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        e.ToString();
                    }
                    s.decreaseSpeed(1f);
                }
            }
        }

    }
}
