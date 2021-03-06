﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    /// <summary>
    /// Concrete class that realizes the IBallisticFramework interface. 
    /// Framework part that connects the class of ballistic calculations with the application logic. 
    /// Transforms internal coordinates according to the game engine coordinates. 
    /// It gives an initiative to ballistic calculations to launch a new calculations.
    /// </summary>
    public class BallisticFramework : IBallisticFramework
    {
        protected IBallisticCalculation calculation;
        DateTime time;
        protected double azimuth, elevation;
        GameObject projectile;
        Vector3 position;    //weapon coordinates
        Quaternion rotation; //weapon rotation
        double x, y, vx, vy; //projectile coordinates centered in initial (0,0) coordinate system

        public BallisticFramework()
        {
            azimuth = 0.0f;
            elevation = 0.0f;
            position = new Vector3(0.0f, 0.0f, 0.0f);
            x = y = vx = vy = 0.0; 
        }
        /// <summary>
        /// Initializes ballistic part of the framework.
        /// </summary>
        /// <param name="projectile"></param>Object on the ballistic scene to be controlled by the ballistics, the missile.
        /// <param name="calculation"></param>Delegate if ballistic calculations.
        /// <param name="azimuth"></param>Azimuth of the ballistic path.
        /// <param name="elevation"></param>Tilting of the tube.
        /// <param name="position"></param>The position of the projectile, written in the Unity Vector3 form.
        /// <param name="speed"></param>Amount of starting missile speed.
        public void Init(GameObject projectile, IBallisticCalculation calculation, double azimuth, double elevation, Vector3 position, double speed)
        {
            this.projectile = projectile;
            this.calculation = calculation;
            this.azimuth = azimuth;
            this.elevation = elevation;
            this.position = position;
            time = DateTime.Now;
            x = 0.0;
            y = 0.0;
            double gamescale = calculation.GetGamescale();
            speed *= gamescale;
            vx = speed * Math.Cos(elevation); //projectile initial conditions
            vy = speed * Math.Sin(elevation); //projectile initial conditions
            //Debug.Log("Ballistic: shot at elevation "+elevation+" radians in azimuthal direction of "+azimuth+" radians starting from x: "+position.x+", y: "+position.y+", z: "+position.z);
        }
        /// <summary>
        /// Initialization of the ballistic part of frameworks. Polymorphism. 
        /// This method takes the object from the Unity engine of the Transform class.
        /// </summary>
        /// <param name="projectile"></param>Object on the ballistic scene to be controlled by the ballistics, the missile.
        /// <param name="calculation"></param>Delegate if ballistic calculations.
        /// <param name="transform"></param>The position and orientation of the tubes, written in the Unity form of Transform.
        /// <param name="speed"></param>Amount of the starting missile speed.
        public void Init(GameObject projectile, IBallisticCalculation calculation, Transform transform, double speed)
        {
            this.projectile = projectile;
            this.calculation = calculation;
            elevation = 360.0f - transform.eulerAngles.x;
            if (elevation > 180.0f)
                elevation -= 360.0f;
            elevation *= Mathf.Deg2Rad;
            azimuth = Mathf.Deg2Rad * transform.eulerAngles.y;
            position = transform.position;

            time = DateTime.Now;
            x = 0.0;
            y = 0.0;
            double gamescale = calculation.GetGamescale();
            speed *= gamescale;
            vx = speed * Math.Cos(elevation); //projectile initial conditions
            vy = speed * Math.Sin(elevation); //projectile initial conditions
            //Debug.Log("Weapon pos: x: " + transform.position.x + ", y: " + transform.position.y + ", z: " + transform.position.z);
            //Debug.Log("Ballistic: shot at elevation " + elevation + " radians in azimuthal direction of " + azimuth + " radians starting from x: " + x + ", y: " + y);
        }
        /// <summary>
        /// Notification of ballistics to start a new calculation. Update on each frame.
        /// </summary>
        public void OnUpdate()
        {
            double x1, y1, z1;
            double seconds;
            if (calculation == null)
                return;
            TimeSpan elapsed = DateTime.Now - time;
            time = DateTime.Now;
            seconds = (elapsed.Seconds * 1000 + elapsed.Milliseconds) / 1000.0;
            // Debug.Log("Seconds elapsed: " + seconds+", posX: "+position);
            calculation.Calculate(ref x, ref y, ref vx, ref vy, seconds);
            //Debug.Log("Ballistic position: x: " + x + ", y: " + y);
            //  right coordinate systems
            //  x ballistics -> z scene direction 
            //  y ballistics -> y scene direction (up)
            // -z ballistics -> x scene direction
            x1 = x * Math.Cos(azimuth);
            y1 = y;
            z1 = x * Math.Sin(azimuth);
            
            position.x = position.x + (float)z1;
            position.y = position.y + (float)y1;
            position.z = position.z + (float)x1;          

            //neglected ballistic projectile rotation
            if (projectile != null) //if projectile exists
                projectile.transform.SetPositionAndRotation(position, rotation);

            //need to stop it when projectile hits target
            
            //Debug.Log("Projectile position: x: " + position.x + ", y: " + position.y + ", z: " + position.z);
        }
    }
}
