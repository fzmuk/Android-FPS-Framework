using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

public class GamePoolManager : MonoBehaviour {

    public PoolMenager poolManager;
    public GameObject BulletPrefab;
    
	// Use this for initialization
	void Start () {
        poolManager = PoolMenager.Instance;
        poolManager.CreatePool(BulletPrefab);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
