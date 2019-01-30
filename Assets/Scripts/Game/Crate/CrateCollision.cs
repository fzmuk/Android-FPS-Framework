using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateCollision : MonoBehaviour {

    CratesManagement crateManagment;

	// Use this for initialization
	void Start () {
        crateManagment = GameObject.Find("GameManager").GetComponent<CratesManagement>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "neprijatelj")
        {
            crateManagment.crates.ReturnCrate(gameObject);
            Debug.Log("nagrada");
        }
    }
  
}
