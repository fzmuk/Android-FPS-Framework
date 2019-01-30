using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    /// <summary>
    /// Class for realization of the IBallisticGauge interface. Used to measure ballistic parameters such as maximum range.
    /// </summary>
    public class BallisticGauge : IBallisticGauge
    {
        protected IBallisticCalculation calculation;
        protected double azimuth, elevation;
        Vector3 position;
        double vx, vy, speed;
        public BallisticGauge()
        {
            azimuth = 0.0f;
            elevation = 0.0f;
            position = new Vector3(0.0f, 0.0f, 0.0f);
        }
        /// <summary>
        /// Inicialization.
        /// </summary>
        /// <param name="calculation"></param>Delegate for statistic calculation.
        /// <param name="speed"></param>Amount of speed.
        /// <param name="elevation"></param>Slope of the tube.
        public void Init(IBallisticCalculation calculation, double speed, double elevation)
        {
            Init(null, calculation, 0.0, elevation, new Vector3(0.0f, 0.0f), speed);
        }
        /// <summary>
        /// Polymorphism. Initialization of this form due to compatibility with the interface.
        /// </summary>
        /// <param name="projectile"></param>It's not used. Due to the compability with IBallisticFramework interface.
        /// <param name="calculation"></param>Delegate for statistic calculation.
        /// <param name="transform"></param>Unity record for position and orientation.
        /// <param name="speed"></param>Amount of speed.
        public void Init(GameObject projectile, IBallisticCalculation calculation, Transform transform, double speed)
        {
            elevation = 360.0f - transform.eulerAngles.x;
            if (elevation > 180.0f)
                elevation -= 360.0f;
            elevation *= Mathf.Deg2Rad;
            Init(projectile, calculation, 0.0, elevation, position, speed);
        }
        /// <summary>
        /// Polymorphism. Initialization of this form due to compatibility with the interface.
        /// </summary>
        /// <param name="projectile"></param>It's not used. Due to the compability with IBallisticFramework interface.
        /// <param name="calculation"></param>Delegate for statistic calculation.
        /// <param name="azimuth"></param>Azimuth of the ballistic path.
        /// <param name="elevation"></param>Slope of the tube.
        /// <param name="position"></param>Position at firing.
        /// <param name="speed"></param>Amount of the speed.
        public void Init(GameObject projectile, IBallisticCalculation calculation, double azimuth, double elevation, Vector3 position, double speed)
        {
            this.calculation = calculation;
            this.elevation = elevation;
            //don't care about azimuth
            double gamescale = calculation.GetGamescale();
            this.speed = speed*gamescale;
            vx = this.speed * Math.Cos(elevation); //projectile initial conditions
            vy = this.speed * Math.Sin(elevation); //projectile initial conditions
        }
        /// <summary>
        /// Notification of ballistics to calculate the next position of the projectile. It's not used.
        /// </summary>
        public void OnUpdate()
        {
            
        }
        /// <summary>
        /// Calculates the range of projectiles. No parameters. Calculation parameters were entered while initialization.
        /// </summary>
        /// <returns></returns>
        //calculating range using current elevation - not maximal range
        public double CalculateRange()
        {
            double seconds, local_x, local_y, local_vx, local_vy, dt;
            seconds = 0.0;
            local_vx = vx;
            local_vy = vy;
            local_x = 0.0;
            local_y = 0.001;
            do
            {
                if (local_vy >= 0.0) //ascending
                    dt = 0.01;
                else if (local_y > 0.0) //descending but above ground plane
                {
                    dt = -local_y / local_vy;
                    if (dt < 0.00001)
                        dt = 0.00001;
                    else if (dt > 0.01)
                        dt = 0.01;
                }
                else //bellow ground plane - will be picked in next iteration
                    dt = 0.001;
                calculation.Calculate(ref local_x, ref local_y, ref local_vx, ref local_vy, dt);
            } while (local_y > 0.0); //passed ground plane
            return local_x;
        }
        /// <summary>
        /// Calculates the range of the projectile at the most favorable angle (elevation). No parameters. 
        /// Calculation parameters were entered while initialization.
        /// </summary>
        /// <returns></returns>
        public double CalculateMaximumRange()
        {
            double elevation = 0.0;
            return CalculateMaximumRange(ref elevation);
        }
        /// <summary>
        /// Calculates the range of projectiles. Elevation parameter.
        /// </summary>
        /// <param name="elevation"></param>Tube inclination (elevation). Transferring references. 
        /// After calculation, the most favorable angle will be returned, which due to aerodynamics does not have to be 45°.
        public double CalculateMaximumRange(ref double elevation)
        {
            double maxRange = 0.0;
            double elevationMax = 0.0;
            double e, e1;
            for(e=30.0; e < 50.0; e += 1.0)
            {
                e1 = e*Mathf.Deg2Rad;
                vx = speed * Math.Cos(e1); //projectile initial conditions
                vy = speed * Math.Sin(e1); //projectile initial conditions
                double range = CalculateRange();
                if (range > maxRange)
                {
                    maxRange = range;
                    elevationMax = e;
                }
            }
            elevation = elevationMax;
            return maxRange;
        }
    }
}
