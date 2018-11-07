using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DisplacementDetection;

namespace PlayerMovement
{
    public class PlayerRotate
    {

        private IDisplacement shiftInput;
        private GameObject player;

        public PlayerRotate(IDisplacement shiftInput, GameObject player)
        {
            this.shiftInput = shiftInput;
            this.player = player;
        }

        public void RotatePlayer()
        {
            var shift = shiftInput.Shift;
            player.transform.Rotate(0f, shift.x, 0f, Space.Self);
        }
    }

}
