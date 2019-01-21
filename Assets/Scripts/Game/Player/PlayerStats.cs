using UnityEngine;
using UnityEngine.UI;
using PlayerAgent;
using Pool;
using UnityEngine.AI;

public class PlayerStats : MonoBehaviour {

    public Image HpProgressBar;
    public Image ArProgressBar;

    public Player Player;
    private GameObject playerSpawnPoint;
    private Image[] progressBars = new Image[2];
    PoolMenager poolManager = PoolMenager.Instance;


    private NavMeshAgent agent;

    // Use this for initialization
    void Start () {

        agent = gameObject.GetComponent<NavMeshAgent>();
        Player = new Player(agent);

        playerSpawnPoint = GameObject.Find("PlayerSpawnPoint");

        Player.Health = 100f;
        Player.Armor = 50f;

        progressBars[0] = HpProgressBar;
        progressBars[1] = ArProgressBar;
        Player.InitStats(progressBars);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Bullet")
        {
            
            Player.ChangeStats(-10f, HpProgressBar, true);
            Player.ChangeStats(-20f, ArProgressBar, false);
            if (Player.Health<=0) Respawn();

            poolManager.ReturnToPool(col.gameObject);
        }
    }

    public void Respawn()
    {
        transform.position = playerSpawnPoint.transform.position;
        Player.Health = 100f;
        Player.Armor = 50f;
        Player.InitStats(progressBars);
    }
}
