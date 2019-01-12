using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProba : MonoBehaviour {

    Animator m_Animator;

    // Use this for initialization
    void Start () {
        m_Animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        m_Animator.Play("walk_shoot_ar");


    }
}
