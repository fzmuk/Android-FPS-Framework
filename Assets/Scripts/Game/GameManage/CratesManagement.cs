using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

public class CratesManagement : MonoBehaviour {

    public GameObject[] SpawnPoints;
    public GameObject CratePrefab;

    private Transform spawnPoints;
    Crates crates = new Crates();

    // Use this for initialization
    void Start () {


        spawnPoints = GameObject.Find("SpawnPoints").transform;
        SpawnPoints = new GameObject[spawnPoints.childCount - 1];

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            SpawnPoints[i] = spawnPoints.GetChild(i+1).gameObject;
        }

        crates.InitCrates(SpawnPoints, CratePrefab);
        crates.SetCrates();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
