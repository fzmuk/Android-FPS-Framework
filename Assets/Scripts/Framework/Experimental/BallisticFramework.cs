using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    public class BallisticFramework : IBallisticFramework
    {
        protected readonly float g = 9.81f;
        protected float mass, speed, drag;
        protected float azimuth, elevation;
        Vector3 position;

        public BallisticFramework(float mass, float speed, float drag)
        {
            this.mass = mass;
            this.speed = speed;
            this.drag = drag;
            azimuth = 0.0f;
            elevation = 0.0f;
            position = new Vector3(0.0f, 0.0f, 0.0f);
            Debug.Log(String.Format("Ballistic created with mass: {0}, init speed: {1}, drag: {2}",mass,speed,drag));

        }

        public void Init(float azimuth, float elevation, Vector3 position)
        {
            this.azimuth = azimuth;
            this.elevation = elevation;
            this.position = position;
            Debug.Log("Ballistic: shot at elevation "+elevation+" radians in azimuthal direction of "+azimuth+" radians starting from x: "+position.x+", y: "+position.y+", z: "+position.z);
        }

        public void Init(Transform transform)
        {
            elevation = 360.0f - transform.eulerAngles.x;
            if (elevation > 180.0f)
                elevation -= 360.0f;
            elevation *= Mathf.Deg2Rad;
            azimuth = Mathf.Deg2Rad * transform.eulerAngles.y;
            position = transform.position;
            Debug.Log("Ballistic: shot at elevation " + elevation + " radians in azimuthal direction of " + azimuth + " radians starting from x: " + position.x + ", y: " + position.y + ", z: " + position.z);
        }

        public void OnUpdate()
        {

        }
    }
}
