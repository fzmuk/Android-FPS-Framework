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
            this.gamescale = gamescale;
            D = 0.5 * Cv * ro * A;
        }
        //overrider hook methods
        protected override double DynamicsX(double vx)
        {
            return -D * Math.Abs(vx) * vx / m;
        }

        protected override double DynamicsY(double vy)
        {
            return -D * Math.Abs(vy) * vy / m - g;
        }
    }
}
