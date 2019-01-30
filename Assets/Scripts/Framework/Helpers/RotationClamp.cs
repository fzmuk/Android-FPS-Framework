using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    /// <summary>
    /// Accessary static class for limiting the angle of rotation.
    /// </summary>
    public static class RotationClamp
    {
        /// <summary>
        /// Function for limiting the angle between lower and higher horizon boundaries.
        /// If the angle is inside the boundarie, it returns the value of that angle,
        /// if it's not, it returns the value closer to the value of that angle.
        /// </summary>
        /// <param name="angle"></param>Angle necessary to limit (in degrees).
        /// <param name="lowerAngle"></param>Maximum angle below horizon (in degrees).
        /// <param name="upperAngle"></param>Maximum angle above horizon (in degrees).
        public static float ClampAngle(float angle, float lowerAngle, float upperAngle)
        {
            float lowerMaxAngle = 360 - upperAngle;
            float upperMinAngle = lowerAngle;

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
