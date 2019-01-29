using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Framework.Experimental
{
    /// <summary>
    /// A class interface that serves to measure ballistic parameters such as 
    /// maximum range and current range.
    /// </summary>
    public interface IBallisticGauge : IBallisticFramework
    {
        void Init(IBallisticCalculation calculation, double speed, double elevation);
        double CalculateRange();
        double CalculateMaximumRange();
        double CalculateMaximumRange(ref double elevation);
    }
}
