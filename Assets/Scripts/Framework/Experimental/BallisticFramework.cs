using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    public class BallisticFramework : IBallisticFramework
    {
        protected IBallisticCalculation calculation;
        DateTime time;
        protected double azimuth, elevation;
        Vector2 position;
        double x, y, vx, vy;

        public BallisticFramework()
        {
            azimuth = 0.0f;
            elevation = 0.0f;
            position = new Vector3(0.0f, 0.0f, 0.0f);
            x = y = vx = vy = 0.0;
        }

        public void Init(IBallisticCalculation calculation, double azimuth, double elevation, Vector3 position, double speed)
        {
            this.calculation = calculation;
            this.azimuth = azimuth;
            this.elevation = elevation;
            this.position = position;
            time = DateTime.Now;
            vx = speed * Math.Cos(elevation);
            vy = speed * Math.Sin(elevation);
            Debug.Log("Ballistic: shot at elevation "+elevation+" radians in azimuthal direction of "+azimuth+" radians starting from x: "+position.x+", y: "+position.y+", z: "+position.z);
        }

        public void Init(IBallisticCalculation calculation, Transform transform, double speed)
        {
            this.calculation = calculation;
            elevation = 360.0f - transform.eulerAngles.x;
            if (elevation > 180.0f)
                elevation -= 360.0f;
            elevation *= Mathf.Deg2Rad;
            azimuth = Mathf.Deg2Rad * transform.eulerAngles.y;
            position = transform.position;
            time = DateTime.Now;
            vx = speed * Math.Cos(elevation);
            vy = speed * Math.Sin(elevation);
            Debug.Log("Ballistic: shot at elevation " + elevation + " radians in azimuthal direction of " + azimuth + " radians starting from x: " + x + ", y: " + y);
        }

        public void OnUpdate()
        {
            
            double seconds;
            if (calculation == null)
                return;
            TimeSpan elapsed = DateTime.Now - time;
            time = DateTime.Now;
            seconds = (elapsed.Seconds * 1000 + elapsed.Milliseconds) / 1000.0;
            Debug.Log("Seconds elapsed: " + seconds);
            calculation.Calculate(ref x, ref y, ref vx, ref vy, seconds);
            //need to stop it when projectile hits target
            Debug.Log("Calculated: x:"+x+", y:"+y+", vx:"+vx+", vy:"+vy);
        }
    }
}
