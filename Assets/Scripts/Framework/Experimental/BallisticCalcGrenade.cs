using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Framework.Experimental
{
    /// <summary>
    /// A concrete class that through the Template method inherits the abstract class BallisticCalculation, 
    /// concretizing its hook methods and thus the fragments of the algorithm for calculating the motion of a projectile. Each concretization relates to the specific dynamics of the projectiles, and this class specifies fast missiles with a Reynolds number less than 1000 and thus a linear dependence of the velocity air velocity.
    /// </summary>
    /* template method pattern */
    public class BallisticCalcGrenade : BallisticCalculation
    {
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="m"></param>Weight of the projectile.
        /// <param name="g"></param>Gravitation acceleration.
        /// <param name="Cv"></param>Air resistance.
        /// <param name="ro"></param>Air density.
        /// <param name="A"></param>The impact section of the missile.
        /// <param name="gamescale"></param>The Scale of the game wrld and the real world.
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
        /// <summary>
        /// Overriden abstract method in which the fragment of the algorithm for 
        /// calculating fast missiles with a Reynolds number above 1000 is implemented.
        /// </summary>
        /// <param name="vx"></param>Horizontal speed component.
        /// <returns></returns>
        //overrider hook methods
        //overrider hook methods
        protected override double DynamicsX(double vx)
        {
            return -D_over_m * vx;
        }
        /// <summary>
        /// Overriden abstract method in which the fragment of the algorithm for 
        /// calculating fast missiles with a Reynolds number above 1000 is implemented.
        /// </summary>
        /// <param name="vy"></param>Vertical speed component.
        /// <returns></returns>
        protected override double DynamicsY(double vy)
        {
            return -D_over_m * vy - g;
        }
    }
}
