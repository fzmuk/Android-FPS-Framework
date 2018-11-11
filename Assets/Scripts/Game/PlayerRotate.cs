using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DisplacementDetection;
using PlayerMovement;

public class PlayerRotate : MonoBehaviour {
    public GameObject player;

    private PlayerMovement.PlayerRotate playerRotate;

	void Start () {
        IDisplacement swipeDetection = player.AddComponent<SwipeDetection>();
        playerRotate = new PlayerMovement.PlayerRotate(swipeDetection, player);
	}

	void Update () {
        playerRotate.RotatePlayer();
    }
}
