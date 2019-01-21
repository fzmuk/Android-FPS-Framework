using Assets.Scripts.Framework.Experimental;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBallistics : MonoBehaviour
{
    protected IBallisticFramework ballistics;

    private const double speed = 20.0;

    // Use this for initialization
    void Awake () {
        ballistics = new BallisticFramework();
    }
	
	// Update is called once per frame
	void Update () {
        ballistics.OnUpdate();
    }

    public void Init(Transform weaponTransform)
    {
        double gamescale = 0.05;
        IBallisticCalculation calculation = new BallisticCalcGrenade(0.3, 9.81, 0.7, 1.23, 0.0025, gamescale); //m, g, Cx, ro, A
        if (ballistics == null) Debug.Log("Ovo je problem");
        ballistics.Init(gameObject, calculation, weaponTransform, speed);
    }
}
