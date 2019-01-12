using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EnemyAgent;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour {

    Animator s_animation;
    NavMeshAgent agent;
    Enemy enemy;
    EnemyActions enemyAct;
    GameObject oponent;
    
	// Use this for initialization
	void Start () {
        s_animation = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemy = new Enemy(agent);
        enemyAct = new EnemyActions(enemy);

        s_animation.Play("idle_gunMiddle_ar");

        enemy.DetectionDistance = 20;
        enemy.StoppingDistance = 10; 
    }
	
	// Update is called once per frame
	void Update () {
        oponent = enemy.FindOponentByTag("neprijatelj");
        float dist = Vector3.Distance(oponent.transform.position, transform.position);


        if (dist <= enemy.DetectionDistance && dist > enemy.StoppingDistance) //ne prebacit na kraju u idle nego shoot anim
        {
            s_animation.Play("walk_shoot_ar");
            enemyAct.Follow(oponent);
        }
        else
        {
            s_animation.Play("idle_gunMiddle_ar");
        }
	}

}
