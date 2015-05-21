using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TEAMSModule
{
    class TWPCalc
    {
        private const int VALUE = 12; 
        public TWPCalc() { }

        public double pulseTRF(double time)
        {
            double calcE = 1 - Math.Pow(Math.E, (-time / VALUE));
            return VALUE * calcE;
        }

        public double continousTRF(double time)
        {
            double calcE = 1 - Math.Pow(Math.E, (-time / VALUE));
            return (VALUE * time) - (VALUE * VALUE * calcE);
        }

        public double servicelifeTRF(double time, int serviceLife)
        {
            if (time <= serviceLife)
            {
                // just use continous
                return continousTRF(time);
            }
            else
            {
                int c_sl = VALUE * serviceLife;
                double e_1 = Math.Pow(Math.E, (-time/VALUE));
                double e_2 = Math.Pow(Math.E, (serviceLife / VALUE) - 1);

                return (c_sl) - (VALUE * VALUE * e_1 * e_2);
            }
        }
    }
}
