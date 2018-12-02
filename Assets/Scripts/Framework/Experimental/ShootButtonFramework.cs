using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    public class ShootButtonFramework : IShootButtonFramework

    {
        public void OnClick()
        {
            Debug.Log("Framework: Button shoot clicked.");
        }

    }
}
