using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{
    public class CameraFollow
    {
        public void Follow (Camera camera, GameObject player, Vector3 offset)
        {
            camera.transform.position = player.transform.position + offset;
        }

    }
}

