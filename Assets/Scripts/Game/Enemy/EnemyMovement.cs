using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EnemyAgent;
using Pool;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour {

    public Transform ExitPoint;

    Animator s_animation;
    Enemy enemy;
    EnemyActions enemyAct;
    GameObject oponent;

    protected GameObject bullet;
    private Transform weaponTransform;
    public WeaponHandler weaponHandler;
    PoolMenager poolManager = PoolMenager.Instance;

    private float range = 10f; //TODO
    private double dist;
    private bool moving = false;
    private float timer = 0.5f;

    // Use this for initialization
    void Start() {
        s_animation = GetComponent<Animator>();
        weaponHandler = gameObject.GetComponentInChildren<WeaponHandler>() as WeaponHandler;
        weaponTransform = weaponHandler.getWeaponTransform();

        ExitPoint = transform.Find("ExitPoint");

        enemy = gameObject.GetComponent<EnemyStats>().Enemy;
        enemyAct = new EnemyActions(enemy);

        s_animation.Play("idle_gunMiddle_ar");

        enemy.DetectionDistance = 20;
        enemy.StoppingDistance = 10;
    }

    // Update is called once per frame
    void Update() {
        oponent = enemy.FindOponentByTag("neprijatelj");
        dist = Vector3.Distance(oponent.transform.position, transform.position);


        dist = System.Math.Floor(dist);

        if (dist <= (enemy.DetectionDistance + 5))
        {
            enemyAct.LookAtPlayer(oponent, 5f);
        }

        if (dist <= enemy.DetectionDistance && dist >= range)
        {
            s_animation.Play("walk_shoot_ar");
            moving = enemyAct.Follow(oponent);
        }

        if (dist > enemy.DetectionDistance) moving = enemyAct.Stop();

        if (dist < range && enemy.Health > 0)
        {
            s_animation.Play("shoot_single_ar");

            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                Shoot();
                timer = 0;
            }

        }

        if (!moving && dist > enemy.DetectionDistance) s_animation.Play("idle_gunMiddle_ar");

    }

    public void Shoot()
    {
        bullet = poolManager.GetFromPool("Bullet");
        bullet.transform.SetPositionAndRotation(weaponHandler.getWeaponTransform().position, weaponHandler.getWeaponTransform().rotation);
        bullet.GetComponent<BulletBallistics>().Init(weaponTransform, poolManager);
    }
}
