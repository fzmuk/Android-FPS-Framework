using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    /* template method pattern */
    public class BallisticCalcBullet : BallisticCalculation
    {

        public BallisticCalcBullet(double m, double g, double Cv, double ro, double A, double gamescale)
        {
            this.g = g * gamescale;
            this.m = m;
            this.Cv = Cv;
            this.ro = ro / gamescale;
            this.A = A;
            this.r = Math.Sqrt(A / Math.PI);
            this.gamescale = gamescale;
            D = 0.5 * Cv * ro * A;
        }
        //overrider hook methods
        protected override double DynamicsX(double vx)
        {
            if (Re>1000.0)
                return -D_over_m * vx * vx;
            else
                return -D_over_m * vx;
        }

        protected override double DynamicsY(double vy)
        {
            if (Re > 1000.0)
                return -D_over_m * Math.Abs(vy) * vy - g;
            else
                return -D_over_m * vy - g;
        }
    }
}
