using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class PainterUpdater : BaseThread
    {
        BasicForm f = null;
        Speedometer s = null;

        Graphics g = null;
        Pen blackPen = null;

        Point point1 = new Point(250, 400);
        

        public PainterUpdater(BasicForm f, Speedometer s)
        {
            blackPen = new Pen(Color.Black, 3);
            g = f.CreateGraphics();
            this.f = f;
            this.s = s;
        }

        public override void RunThread()
        {
            while (true)
            {
                if (s.isChange())
                {
                    System.Threading.Thread.Sleep(10);
                    this.drawLineAtAngle(s.getSpeed());
                }
            }   
        }


        private void drawLineAtAngle(float angle)
        {
            g.Clear(Color.White);
            Point point2 = new Point((int)(-250 + 150 * Math.Cos(angle * Math.PI / 180)) * (-1), (int)(-400 + 150 * Math.Sin(angle * Math.PI / 180)) * (-1));
            g.DrawLine(blackPen, point1, point2);
        }
    }
}
