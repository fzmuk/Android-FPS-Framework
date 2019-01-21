using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DisplacementDetection;
using PlayerAgent;

public class PlayerRotate : MonoBehaviour {
    public GameObject player;
    public GameObject playerHands;

    private PlayerAgent.PlayerRotate playerRotate;

	void Start () {
        IDisplacement swipeDetection = player.AddComponent<SwipeDetection>();
        playerRotate = new PlayerAgent.PlayerRotate(swipeDetection, playerHands, player);
	}

    void Update ()
    {
        playerRotate.RotatePlayer();
    }
}
