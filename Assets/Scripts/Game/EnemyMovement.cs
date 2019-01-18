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

    private float range = 10f;
    private double dist;
    private bool following = false;

    // Use this for initialization
    void Start () {
        s_animation = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        enemy = gameObject.GetComponent<EnemyStats>().Enemy;
        enemyAct = new EnemyActions(enemy);

        s_animation.Play("idle_gunMiddle_ar");

        enemy.DetectionDistance = 20;
        enemy.StoppingDistance = 10; 
    }
	
	// Update is called once per frame
	void Update () {
        oponent = enemy.FindOponentByTag("neprijatelj");
        dist = Vector3.Distance(oponent.transform.position, transform.position);


        dist = System.Math.Floor(dist);

        if (dist <= (enemy.DetectionDistance + 5) && dist > enemy.StoppingDistance)
        {
            enemyAct.LookAtPlayer(oponent, 5f);
            //Debug.Log(dist);
        }

        if (dist <= enemy.DetectionDistance && dist > enemy.StoppingDistance) //ne prebacit na kraju u idle nego shoot anim
        {
            s_animation.Play("walk_shoot_ar");
            following = enemyAct.Follow(oponent);
            Debug.Log(following); 
        }

        if(dist <= range && enemy.Health > 0)
        {
            enemyAct.LookAtPlayer(oponent, 5f);
            s_animation.Play("shoot_single_ar");
        }

        if (dist > enemy.DetectionDistance && !following) s_animation.Play("idle_gunMiddle_ar");

    }

}
