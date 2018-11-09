using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public static class RotationClamp
    {
        public static float ClampAngle(float angle, float min, float max)
        {
            float lowerMaxAngle = 360 - max;
            float upperMinAngle = min;

            float middleAngle = (lowerMaxAngle + upperMinAngle) / 2;

            if (angle > upperMinAngle && angle < lowerMaxAngle)
            {

                if (angle > middleAngle)
                {
                    return lowerMaxAngle;
                }
                else
                {
                    return upperMinAngle;
                }
            }

            return angle;
        }
    }
}
