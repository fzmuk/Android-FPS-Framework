using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    public interface IBallisticFramework
    {
        void Init(float azimuth, float elevation, Vector3 position);
        void OnUpdate();
    }
}
