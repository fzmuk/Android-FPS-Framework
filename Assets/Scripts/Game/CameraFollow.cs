using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMovement;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public Camera cam;

    private Vector3 offset;
    private PlayerMovement.CameraFollow obj = new PlayerMovement.CameraFollow();

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        //player.transform.Translate(Vector3.forward * Time.deltaTime);

        obj.Follow(cam, player, offset);
	}
}
