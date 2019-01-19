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
            this.A = A * 5.0;
            this.r = Math.Sqrt(A / Math.PI);
            this.gamescale = gamescale;
            D = 0.5 * Cv * ro * A;
        }
        //overrider hook methods
        protected override double DynamicsX(double vx)
        {
            return -D_over_m * vx;
        }

        protected override double DynamicsY(double vy)
        {
            return -D_over_m * vy - g;
        }
    }
}
