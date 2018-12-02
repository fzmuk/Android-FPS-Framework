using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    public class BallisticFramework : IBallisticFramework
    {
        public void Init()
        {
            Debug.Log("Framework: Ballistic initialized.");
        }

        public void OnUpdate()
        {
            Debug.Log("Framework: Ballistic updated.");
        }
    }
}
