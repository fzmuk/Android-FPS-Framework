using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    public class BallisticCalcBullet : IBallisticCalculation
    {
        private double g;
        private double m, Cv, ro, A, D;
        public BallisticCalcBullet(double m, double Cv, double ro, double A)
        {
            g = 9.81;
            m = 0.02;
            Cv = 0.5;
            ro = 1.23;
            A = 0.0001;
            D = 0.5 * Cv * ro * A;
        }

        public void Calculate(ref double vx, ref double vy, ref double x, ref double y, ref double angle, ref double t, double h)
        {
            RungeKuttaDynamics(ref vx, ref vy, h);
            x += vx * h;
            y += vy * h;
            t += h;
            if (vx > 0.00001 || vx < -0.00001)
                angle = (float)Math.Atan(vy / vx);
            else if (vx >= 0)
                angle = 3.1415927 / 2.0;
            else
                angle = -3.1415927 / 2.0;
        }
        public void Calculate(ref double x, ref double y, ref double vx, ref double vy, double h)
        {
            RungeKuttaDynamics(ref vx, ref vy, h);
            x += h * vx;
            y += h * vy;
        }

        private void RungeKuttaDynamics(ref double vx, ref double vy, double h )
        {
            double sixth = 1.0 / 6.0;
            double k1, k2, k3, k4;

            k1 = h * DynamicsX(vx);
            k2 = h * DynamicsX(vx + k1 * 0.5);
            k3 = h * DynamicsX(vx + k2 * 0.5);
            k4 = h * DynamicsX(vx + k3);
            vx += (k1 + k2 * 2.0 + k3 * 2.0 + k4) * sixth;

            k1 = h * DynamicsY(vy);
            k2 = h * DynamicsY(vy + k1 * 0.5);
            k3 = h * DynamicsY(vy + k2 * 0.5);
            k4 = h * DynamicsY(vy + k3);
            vy += (k1 + k2 * 2.0 + k3 * 2.0 + k4) * sixth;
        }

        private double DynamicsX(double vx)
        {
            return -D * Math.Abs(vx) * vx / m;
        }

        private double DynamicsY(double vy)
        {
            return -D * Math.Abs(vy) * vy / m - g;
        }
    }
}
