using System;
using System.Collections.Generic;
using UnityEngine;
using DisplacementDetection;
using Helpers;

namespace PlayerAgent
{
    public class PlayerRotate
    {

        private IDisplacement shiftInput;
        private GameObject verticalRotationObject;
        private GameObject horizontalRotationObject;


        public float AngleLimitUp { get; set; }
        public float AngleLimitDown { get; set; }

        public PlayerRotate(IDisplacement shiftInput, GameObject verticalRotationObject, GameObject horizontalRotationObject)
        {
            this.shiftInput = shiftInput;
            this.verticalRotationObject = verticalRotationObject;
            this.horizontalRotationObject = horizontalRotationObject;
            AngleLimitUp = 45f;
            AngleLimitDown = 45f;
        }

        public void RotatePlayer()
        {
            var shift = shiftInput.Shift;

            // vertical rotation
            verticalRotationObject.transform.Rotate(Vector3.left, shift.y, Space.Self);
            //clamp up-down angle
            var anglesVector = verticalRotationObject.transform.eulerAngles;
            var angle = anglesVector.x;
            anglesVector.x = RotationClamp.ClampAngle(angle, AngleLimitDown, AngleLimitUp);
            verticalRotationObject.transform.eulerAngles = anglesVector;

            // horizontal rotation
            horizontalRotationObject.transform.Rotate(Vector3.up, shift.x, Space.World);
        }
    }

}
