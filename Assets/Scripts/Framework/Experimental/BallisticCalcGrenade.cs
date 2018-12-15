using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Framework.Experimental
{
    /* template method pattern */
    public class BallisticCalcGrenade : BallisticCalculation
    {
        public BallisticCalcGrenade(double m, double g, double Cv, double ro, double A, double gamescale)
        {
            this.g = g * gamescale;
            this.m = m;
            this.Cv = Cv;
            this.ro = ro / gamescale;
            this.A = A;
            this.gamescale = gamescale;
            D = 0.5 * Cv * ro * A;
        }
        //overrider hook methods
        protected override double DynamicsX(double vx)
        {
            return -D * vx / m;
        }

        protected override double DynamicsY(double vy)
        {
            return -D * vy / m - g;
        }
    }
}
