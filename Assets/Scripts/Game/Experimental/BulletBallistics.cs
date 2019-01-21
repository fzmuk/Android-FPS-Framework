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

        IBallisticCalculation calculation = new BallisticCalcBullet(0.3, 9.81, 0.7, 1.23, 0.0025, gamescale); //m, g, Cx, ro, A
        IBallisticGauge gauge = new BallisticGauge();

        ballistics.Init(gameObject, calculation, weaponTransform, speed);


        gauge.Init(null, calculation, weaponTransform, 600.0);


        double range = gauge.CalculateRange();

        double elevation = 360.0f - weaponTransform.eulerAngles.x;
        if (elevation > 180.0f)
            elevation -= 360.0f;
        Debug.Log("Projectile range: " + range);

        if (range < 50f) range = 50f; //hack: if weopn angle is <0 range is ~0

        StartCoroutine(ReturnToPool((float)(range / speed)));        
    }

            
    IEnumerator ReturnToPool(float time)
    {
        yield return new WaitForSeconds(time);
        poolManager.ReturnToPool(gameObject);
    }
}
