using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Clutch
    {
        private bool pressedClutch = false;
        private float lastSpeed = 0f;
        private int lastGear = 0;
        private bool pressFinished = false;
        private Waiter w = null;


        public bool isClutchPressed()
        {
            return pressedClutch;
        }

        public void setLastSpeed(float amount)
        {
            this.lastSpeed = amount;
        }

        public void Press(Speedometer s, GearChanger gc)
        {

            this.pressedClutch = true;
            this.lastSpeed = s.getSpeed();
            this.lastGear = gc.getGear();
            //need to make this function unblocking
            if (gc.getGear() != 0)
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    while (this.isClutchPressed()) //while engine isn't engaged
                    {
                        System.Threading.Thread.Sleep(10);
                        s.decreaseSpeed(5f);
                    }
                }).Start();

                
                this.pressFinished = true;
            }
            


        }

        public void Release(Speedometer s, GearChanger gc)
        {
            
            this.pressedClutch = false;
            int currentGear = gc.getGear();
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true; //must wait a time gap till pedal is released fully
                w = new Waiter(10);
                w.RunThread();
            }).Start();
            if (currentGear > this.lastGear)
            {
                if (this.lastSpeed > 60f)
                {
                    s.setSpeed(this.lastSpeed - 25f);
                } else if (this.lastSpeed < 20f)
                {
                    s.KillEngine();
                    Console.WriteLine("engine stopped " + this.lastSpeed.ToString());
                }            
            } else if (currentGear < this.lastGear)
            {
                if (currentGear != 0)
                {
                    if (this.lastSpeed < 120f && this.lastSpeed > 20f)
                    {
                        s.setSpeed(this.lastSpeed + 25f);
                    } else if (this.lastSpeed < 20f)
                    {
                        s.KillEngine();
                        Console.WriteLine("engine stopped ");
                    }
                    
                }  
            }
            else if (currentGear == this.lastGear && currentGear != 0)
            {
                s.setSpeed(this.lastSpeed);
            }
        }
    }
}
