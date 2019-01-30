using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    /// <summary>
    /// A concrete class that through the Template method inherits the abstract class BallisticCalculation, 
    /// concretizing its hook methods and thus the fragments of the algorithm for calculating the motion of a projectile. 
    /// Each concretization relates to the specific dynamics of the projectile, 
    /// and this class specifies rapid missiles with a Reynolds number greater than 1000 
    /// and thus a quadratic dependence of the velocity air velocity.
    /// </summary>
    public class BallisticCalcBullet : BallisticCalculation
    {
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="m"></param>Weight of the projectile.
        /// <param name="g"></param>Gravitation acceleration.
        /// <param name="Cv"></param>Air resistance.
        /// <param name="ro"></param>Air density.
        /// <param name="A"></param>The impact section of the missile.
        /// <param name="gamescale"></param>The Scale of the game world and the real world.
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
        /// <summary>
        /// Overriden abstract method in which the fragment of the algorithm for 
        /// calculating fast missiles with a Reynolds number above 1000 is implemented.
        /// </summary>
        /// <param name="vx"></param>Horizontal speed component.
        protected override double DynamicsX(double vx)
        {
            if (Re>1000.0)
                return -D_over_m * vx * vx;
            else
                return -D_over_m * vx;
        }
        /// <summary>
        /// Overriden abstract method in which the fragment of the algorithm for 
        /// calculating fast missiles with a Reynolds number above 1000 is implemented.
        /// </summary>
        /// <param name="vy"></param>Vertical speed component.
        protected override double DynamicsY(double vy)
        {
            if (Re > 1000.0)
                return -D_over_m * Math.Abs(vy) * vy - g;
            else
                return -D_over_m * vy - g;
        }
    }
}
