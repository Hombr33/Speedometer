using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    

    public class GearChanger
    {
        private Waiter w = null;
        private int gear;
        private bool canGearUP;
        private bool canGearDOWN;
        private bool change;

        public GearChanger()
        {
            this.change = false;
            this.gear = 0;
            this.canGearDOWN = false;
            this.canGearUP = true;
        }

        public void ShiftUP(Speedometer s)
        {
            float speed = s.getSpeed();
            if (canGearUP)
            {
                GearUP(speed); //change gear without delay
            }
        }

        public void ShiftDOWN(Speedometer s)
        {
            if (canGearDOWN)
            {
                GearDOWN(); //change gear without delay
            }
        }

        void GearUP(float last_speed)
        {
            if (this.gear == 0 && last_speed > 10f)
            {
                return;
            }
            this.change = true;
            this.gear += 1;
            this.canGearDOWN = true;
            if (this.gear == 6)
            {
                this.canGearUP = false;
            }
            
        }

        void GearDOWN()
        {
            this.change = true;
            this.gear -= 1;
            this.canGearUP = true;
            if (this.gear == 0)
            {
                this.canGearDOWN = false;
            }
            
        }

        //Util functions

        public int getGear()
        {
            return this.gear;
        }

        public bool isChange()
        {
            return this.change;
        }

        public void setChange(bool b)
        {
            this.change = b;
        }

    }
}
