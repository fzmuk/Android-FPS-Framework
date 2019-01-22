using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{


    public class BallisticGauge : IBallisticGauge
    {
        protected IBallisticCalculation calculation;
        protected double azimuth, elevation;
        Vector2 position;
        double vx, vy, speed;
        public BallisticGauge()
        {
            azimuth = 0.0f;
            elevation = 0.0f;
            position = new Vector2(0.0f, 0.0f);
        }

        public void Init(IBallisticCalculation calculation, double speed, double elevation)
        {
            Init(null, calculation, 0.0, elevation, new Vector2(0.0f, 0.0f), speed);
        }
        public void Init(IBallisticCalculation calculation, double speed, double height, double elevation)
        {
            Init(null, calculation, 0.0, elevation, new Vector2(0.0f, (float)height), speed);
        }

        //due to interface compatibility
        public void Init(GameObject projectile, IBallisticCalculation calculation, Transform transform, double speed)
        {
            elevation = 360.0f - transform.eulerAngles.x;
            if (elevation > 180.0f)
                elevation -= 360.0f;
            elevation *= Mathf.Deg2Rad;
            Init(projectile, calculation, 0.0, elevation, new Vector2(0.0f, transform.position.y), speed);
        }

        //due to interface compatibility
        public void Init(GameObject projectile, IBallisticCalculation calculation, double azimuth, double elevation, Vector3 position, double speed)
        {
            this.calculation = calculation;
            this.elevation = elevation;
            //don't care about azimuth
            double gamescale = calculation.GetGamescale();
            this.speed = speed*gamescale;
            this.position.y = position.y;
            vx = this.speed * Math.Cos(elevation); //projectile initial conditions
            vy = this.speed * Math.Sin(elevation); //projectile initial conditions
        }


        public void OnUpdate()
        {
            
        }
        //calculating range using current elevation - not maximal range
        public double CalculateRange()
        {
            double seconds, local_x, local_y, local_vx, local_vy, dt;
            seconds = 0.0;
            local_vx = vx;
            local_vy = vy;
            local_x = 0.0;
            local_y = this.position.y;
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
        public double CalculateMaximumRange()
        {
            double elevation = 0.0;
            return CalculateMaximumRange(ref elevation);
        }

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
