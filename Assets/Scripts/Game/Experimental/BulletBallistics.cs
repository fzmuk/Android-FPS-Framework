using Assets.Scripts.Framework.Experimental;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBallistics : MonoBehaviour
{
    protected IBallisticFramework ballistics;
    protected PoolMenager poolManager;

    private const double speed = 20.0;
    private const double gamescale = 0.05;

    // Use this for initialization
    void Awake () {
        ballistics = new BallisticFramework();
    }
	
	// Update is called once per frame
	void Update () {
        ballistics.OnUpdate();
    }


    public void Init(Transform weaponTransform, PoolMenager poolManager)
    {
        this.poolManager = poolManager;

        IBallisticCalculation calculation = new BallisticCalcGrenade(0.3, 9.81, 0.7, 1.23, 0.0025, gamescale); //m, g, Cx, ro, A
        IBallisticGauge gauge = new BallisticGauge();

        ballistics.Init(gameObject, calculation, weaponTransform, speed);

        //gauge test1
        if (gauge != null)
        {
            calculation = new BallisticCalcBullet(0.03, 9.81, 0.5, 1.23 / gamescale, 0.00006, gamescale); //m, g, Cx, ro, A
            gauge.Init(null, calculation, weaponTransform, 600.0);

            double range = gauge.CalculateRange();

            double elevation = 360.0f - weaponTransform.eulerAngles.x;
            if (elevation > 180.0f)
                elevation -= 360.0f;
            Debug.Log("Projectile range: " + range);

            StartCoroutine(ReturnToPool((float)(range / speed)));
        }

        //gauge test2
        if (gauge != null)
        {
            calculation = new BallisticCalcBullet(0.03, 9.81, 0.5, 1.23 / gamescale, 0.00006, gamescale); //m, g, Cx, ro, A
            gauge.Init(calculation, 600.0, 45.0);

            double elevation = 0.0;
            double range = gauge.CalculateMaximumRange(ref elevation);
            Debug.Log("Projectile max. range: " + range);
        }        
    }

            
    IEnumerator ReturnToPool(float time)
    {
        yield return new WaitForSeconds(time);
        poolManager.ReturnToPool(gameObject);
    }
}
