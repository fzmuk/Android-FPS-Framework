using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Framework.Experimental
{
    interface IBallisticCalculation
    {
        void Calculate(ref double vx, ref double vy, ref double x, ref double y, ref double angle, ref double time, double step);
    }
}
