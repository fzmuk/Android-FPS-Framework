using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DisplacementDetection;
using PlayerMovement;

public class PlayerRotate : MonoBehaviour {

    public GameObject player;
    public GameObject playerHands;

    private PlayerMovement.PlayerRotate playerRotate;

    private SwipeDetection swipeDetection;

	void Start () {
        swipeDetection = new SwipeDetection();
        playerRotate = new PlayerMovement.PlayerRotate(swipeDetection, playerHands, player);
	}

	void Update () {
        swipeDetection.UpdateShift();
        playerRotate.RotatePlayer();
    }
}
