using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Speedometer
    {

        private  float speed = 0f;
        private volatile bool wPressed = false;
        private volatile bool change = true;
        private bool engineOn = false;


        public void increaseSpeed(float amount)
        {
            if (this.engineOn)
            {
                if (this.speed < 160)
                {
                    this.change = true;
                    this.speed += amount;
                }
                else
                {
                    this.change = false;
                }
            }
            
        }

        public void decreaseSpeed(float amount)
        {
            if (this.engineOn)
            {
                if (!this.wPressed && this.speed > 20f)
                {
                    this.change = true;
                    this.speed -= amount;
                }
                else if (!this.wPressed && this.speed > 10f)
                {
                    this.change = true;
                    this.speed -= 0.05f;
                }
                else
                {
                    this.change = false;
                }
            } else
            {
                this.change = true;
                while (this.speed > 0.001f)
                {
                    this.speed -= 10f;
                }
               
            }
            
        }

        public void Ignition()
        {
            this.engineOn = true;
        }

        public void KillEngine()
        {
            this.engineOn = false;
        }

        public void setSpeed(float amount)
        {
            if (this.engineOn)
            {
                while (this.speed < amount)
                {
                    System.Threading.Thread.Sleep(20); //Gently increase speed after clutch's been pressed
                    this.increaseSpeed(6.5f);
                }
            }
            
        }

        public float getSpeed()
        {
            return this.speed;
        }

        public void setwPressed(bool b)
        {
            this.wPressed = b;
        }

        public bool getwPressed()
        {
            return this.wPressed;
        }

        public bool isChange()
        {
            return this.change;
        }

    }
}
