using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Framework.Experimental
{
    /// <summary>
    /// Apstract class that implements BallisicCalculation, the calculation of ballistics, 
    /// or the integration of the missile path along with the calculated air resistance. 
    /// Template method pattern: the class has two hook methods that in specific classes contain fragments 
    /// of algorithms that differ depending on whether fast or slow projectiles are counted.
    /// </summary>
    /* template method pattern */
    public abstract class BallisticCalculation : IBallisticCalculation
    {
        //hook methods
        protected abstract double DynamicsX(double vx);
        protected abstract double DynamicsY(double vy);

        //physical variables
        protected double g;
        protected double m, Cv, ro, A, D, nu, r, v;
        protected double Re; //reynolds number
        protected double D_over_m;
        protected double gamescale;
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public BallisticCalculation()
        {
            g = 9.81;
            m = 0.03;
            Cv = 0.5;
            ro = 1.23;
            r = 0.008;
            A = r * r * Math.PI;
            D = 0.5 * Cv * ro * A;
            nu = 0.0000182; //kinematic viscosity of air at 20 deg C 
            gamescale = 1.0;
        }

        public double GetGamescale()
        {
            return gamescale;
        }
        /// <summary>
        /// Method that calculates part of the missile track using RK4 
        /// (Runge-Angle 4th order) method of numerical integration.
        /// </summary>
        /// <param name="vx"></param>Y component speed. Vertical speed component. Transfer through reference.
        /// <param name="vy"></param>X component speed. Horizonatl speed component. Transfer through reference.
        /// <param name="x"></param>X position component. Horizontal component of the position (distance). Transfer through references.
        /// <param name="y"></param>Y position component. Vertical component of the position (height). Transfer through references.
        /// <param name="angle"></param>Angle of the projectile. Transfer through reference.
        /// <param name="t"></param>Time of the flight. Transfer through reference.
        /// <param name="h"></param>Time slice between two consecutive calculations. Discrete integration time.
        public void Calculate(ref double vx, ref double vy, ref double x, ref double y, ref double angle, ref double t, double h)
        {
            RungeKuttaDynamics(ref vx, ref vy, h);
            x += vx * h;
            y += vy * h;
            t += h;
            if (vx > 0.00001 || vx < -0.00001)
                angle = (float)Math.Atan(vy / vx);
            else if (vx >= 0)
                angle = 3.1415927 * 0.5;
            else
                angle = -3.1415927 * 0.5;
        }
        /// <summary>
        /// Other variant (polymorphism). Method that calculates part of the missile track using 
        /// RK4 (Runge-Angle 4th order) method of numerical integration.
        /// </summary>
        /// <param name="vx"></param>Y component speed. Vertical speed component. Transfer through reference.
        /// <param name="vy"></param>X component speed. Horizonatl speed component. Transfer through reference.
        /// <param name="x"></param>X position component. Horizontal component of the position (distance). Transfer through references.
        /// <param name="y"></param>Y position component. Vertical component of the position (height). Transfer through references.
        /// <param name="h"></param>Time slice between two consecutive calculations. Discrete integration time.
        public void Calculate(ref double x, ref double y, ref double vx, ref double vy, double h)
        {
            RungeKuttaDynamics(ref vx, ref vy, h);
            x += h * vx;
            y += h * vy;
        }
        /// <summary>
        /// Private method - algorithm Runge-Angle 4th order.
        /// </summary>
        /// <param name="vx"></param>Y component speed. Vertical speed component. Transfer through reference.
        /// <param name="vy"></param>X component speed. Horizonatl speed component. Transfer through reference.
        /// <param name="h"></param>Time slice between two consecutive calculations. Discrete integration time.
        private void RungeKuttaDynamics(ref double vx, ref double vy, double h)
        {
            double sixth = 1.0 / 6.0;
            double k1, k2, k3, k4;

            v = Math.Sqrt(vx * vx + vy * vy);
            Re = 2.0 * v * r / nu; //Reynolds' number

            D_over_m = D / m;

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
    }
}
