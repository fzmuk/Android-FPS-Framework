using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Framework.Experimental
{
    public interface IBallisticFramework
    {
        void Init(float azimuth, float elevation);
        void OnUpdate();
    }
}
