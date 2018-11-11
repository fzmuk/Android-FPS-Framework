using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public Joystick JoystickControl;

    private PlayerMovement.MovePlayer agent;
    
    // Use this for initialization
    void Start () {
        var joystick = JoystickControl.GetComponent<Joystick>().virtualJoystick;
        agent = new PlayerMovement.MovePlayer(gameObject, joystick);
    }
	
	// Update is called once per frame
	void Update () {
        agent.PlayerMove(5000);
    }
}
