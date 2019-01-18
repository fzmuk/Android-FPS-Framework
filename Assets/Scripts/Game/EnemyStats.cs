using EnemyAgent;
using UnityEngine;
using UnityEngine.AI;
using Pool;

public class EnemyStats : MonoBehaviour {

    Animator m_Animator;
    NavMeshAgent agent;
    public Enemy Enemy;
    public Material Red;
    public Material Yellow;
    public Material Green;

    PoolMenager poolManager = PoolMenager.Instance;

    // Use this for initialization
    void Awake() {
        m_Animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Enemy = new Enemy(agent);

        Enemy.Health = 100f;
    }

    // Update is called once per frame
    void Update() {

        //m_Animator.Play("walk_shoot_ar");
        if(Enemy.Health > 66) gameObject.transform.GetChild(0).GetComponent<Renderer>().material = Green;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            var hp = Enemy.ChangeHealth(-20f);
            if (hp * 100 <= 66) 
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material = Yellow;
            if(hp * 100 <= 33)
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material = Red;

            if (Enemy.Health <= 0) Die();

            //poolManager.ReturnToPool(col.gameObject);
        }
    }

    void Die()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        m_Animator.Play("die_back_rest");
        Destroy(gameObject, 5f);
    }
}
