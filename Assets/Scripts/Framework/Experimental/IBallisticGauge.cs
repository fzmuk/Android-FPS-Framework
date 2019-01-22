using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Framework.Experimental
{
    public interface IBallisticGauge : IBallisticFramework
    {
        void Init(IBallisticCalculation calculation, double speed, double elevation);
        void Init(IBallisticCalculation calculation, double speed, double height, double elevation);
        double CalculateRange();
        double CalculateMaximumRange();
        double CalculateMaximumRange(ref double elevation);
    }
}
