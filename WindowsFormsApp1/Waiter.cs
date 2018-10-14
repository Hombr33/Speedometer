using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Waiter : BaseThread
    {
        private int n_milisec = 0;
        private volatile static bool stop = false;

        public Waiter(int n)
        {
            this.n_milisec = n;
        }

        public static bool getStop()
        {
            return stop;
        }

        public override void RunThread()
        {
            stop = true;
            System.Threading.Thread.Sleep(this.n_milisec);
            stop = false;
        }

    }
}
