using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

public class CratesManagement : MonoBehaviour {

    public GameObject[] SpawnPoints;
    public GameObject CratePrefab;
    public Crates crates = new Crates();

    private Transform spawnPoints;    

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
        StartCoroutine("Reset");
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(20f);
        crates.SetCrates();
        StartCoroutine("Reset");
    }

}
