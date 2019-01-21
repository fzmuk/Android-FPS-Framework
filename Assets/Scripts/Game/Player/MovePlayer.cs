using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerAgent;

public class MovePlayer : MonoBehaviour {

    public Joystick JoystickControl;
    private Player player;

    private PlayerAgent.MovePlayer playerMove;    

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<PlayerStats>().Player;
        var joystick = JoystickControl.GetComponent<Joystick>().virtualJoystick;
        playerMove = new PlayerAgent.MovePlayer(player, joystick);
    }
	
	// Update is called once per frame
	void Update () {
        playerMove.PlayerMove(200); //za mob 200, za komp 2000
    }
}
