using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BasicForm : Form
    {

        private Speedometer s = null;
        private GearChanger gc = null;
        private Clutch c = null;
        private Waiter w = new Waiter(100);

        public BasicForm(Speedometer s, GearChanger gc, Clutch c)
        {
            this.s = s;
            this.gc = gc;
            this.c = c;
            
            InitializeComponent();
        }

        public void BasicForm_Load(object sender, EventArgs e)
        {

        }

        public void BasicForm_Paint(object sender, PaintEventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                PainterUpdater pu = new PainterUpdater(this, s);
                pu.RunThread();
            }).Start();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                PainterUpdater2 pu2 = new PainterUpdater2(this, gc);
                pu2.RunThread();
            }).Start();

        }

        public void BasicForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 81 && !c.isClutchPressed()) //if press clutch (q) and haven't before
            {
                Action action = () => c.Press(s, gc);
                this.Invoke(action);
            } else if (e.KeyValue == 80 && c.isClutchPressed() && !Waiter.getStop()) //if press shift_up(p) and clutch is pressed
            {
                gc.ShiftUP(s);
            } else if (e.KeyValue == 76 && c.isClutchPressed() && !Waiter.getStop())
            {
                gc.ShiftDOWN(s);
            } else if (e.KeyValue == 87 && !Waiter.getStop() && !c.isClutchPressed())
            {
                
                s.setwPressed(true);
                switch (gc.getGear())
                {
                    case 0:
                        s.increaseSpeed(8f);
                        break;
                    case 1:
                        s.increaseSpeed(2f);
                        break;
                    case 2:
                        s.increaseSpeed(1.5f);
                        break;
                    case 3:
                        s.increaseSpeed(1f);
                        break;
                    case 4:
                        s.increaseSpeed(0.9f);
                        break;
                    case 5:
                        s.increaseSpeed(0.7f);
                        break;
                    case 6:
                        s.increaseSpeed(0.5f);
                        break;
                }
                
            } else if (e.KeyValue == 81 && s.getwPressed())
            {
                s.setwPressed(false);
                Action action = () => c.Press(s, gc);
                this.Invoke(action);
            } else if (e.KeyValue == 87 && c.isClutchPressed() && gc.getGear() == 1)
            {

                s.Ignition();
                c.setLastSpeed(30f);
                s.setSpeed(30f);
            }
            

        }

        public void BasicForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 81 && c.isClutchPressed())
            {
                Action action = () => c.Release(s, gc);
                this.Invoke(action);
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    float value;
                    switch (gc.getGear())
                    {
                        case 1:
                            value = 0.1f;
                            break;
                        case 2:
                            value = 0.2f;
                            break;
                        case 3:
                            value = 0.3f;
                            break;
                        case 4:
                            value = 0.35f;
                            break;
                        case 5:
                            value = 0.4f;
                            break;
                        case 6:
                            value = 0.5f;
                            break;
                        default:
                            value = 0.2f;
                            break;
                    }
                    while (!s.getwPressed() && !c.isClutchPressed())
                    {
                        System.Threading.Thread.Sleep(10);
                        s.decreaseSpeed(value);
                    }
                }).Start();
            } else if (e.KeyValue == 87 && !c.isClutchPressed())
            {
                s.setwPressed(false);
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    while (!s.getwPressed() && !c.isClutchPressed())
                    {
                        System.Threading.Thread.Sleep(10);
                        s.decreaseSpeed(0.3f);
                    }
                }).Start();
            }
        }
    }
}
