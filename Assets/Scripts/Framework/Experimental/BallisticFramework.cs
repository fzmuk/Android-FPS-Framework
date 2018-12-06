using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    public class BallisticFramework : IBallisticFramework
    {
        private readonly float g = 9.81f;
        private float mass, speed, drag;

        public BallisticFramework(float mass, float speed, float drag)
        {
            this.mass = mass;
            this.speed = speed;
            this.drag = drag;
            Debug.Log(String.Format("Ballistic created with mass: {0}, init speed: {1}, drag: {2}",mass,speed,drag));

        }

        public void Init(float azimuth, float elevation)
        {
            Debug.Log("Balistic shot at elevation "+elevation+" radians in azimuthal direction of "+azimuth+" radians");
        }

        public void OnUpdate()
        {

        }
    }
}
