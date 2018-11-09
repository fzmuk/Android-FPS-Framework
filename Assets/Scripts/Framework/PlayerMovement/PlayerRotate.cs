using System;
using System.Collections.Generic;
using UnityEngine;
using DisplacementDetection;
using Helpers;

namespace PlayerMovement
{
    public class PlayerRotate
    {

        private IDisplacement shiftInput;
        private GameObject player;

        public float AngleLimitUp { get; set; }
        public float AngleLimitDown { get; set; }

        public PlayerRotate(IDisplacement shiftInput, GameObject player)
        {
            this.shiftInput = shiftInput;
            this.player = player;
            AngleLimitUp = 45f;
            AngleLimitDown = 45f;
        }


        public void RotatePlayer()
        {
            var shift = shiftInput.Shift;

            // rotation up-down
            player.transform.Rotate(Vector3.left, shift.y, Space.Self);
            //clamp up-down angle
            var anglesVector = player.transform.eulerAngles;
            var angle = anglesVector.x;
            anglesVector.x = RotationClamp.ClampAngle(angle, AngleLimitDown, AngleLimitUp);
            player.transform.eulerAngles = anglesVector;

            //rotation left-right
            player.transform.Rotate(Vector3.up, shift.x, Space.World);
        }
    }

}
