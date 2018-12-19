using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    public interface IBallisticFramework
    {
        void Init(GameObject projectile, IBallisticCalculation calculation, double azimuth, double elevation, Vector3 position, double speed);
        void Init(GameObject projectile, IBallisticCalculation calculation, Transform transform, double speed);
        void OnUpdate();
    }
}
