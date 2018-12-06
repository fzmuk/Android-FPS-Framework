using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    float WeaponAngle;
    // Use this for initialization
    void Start ()
    {
    }

    /* Weapon angle is in rangle -pi/2 to pi/2 radians*/
    public float GetWeaponElevation()
    {
        float angle = 360.0f - transform.eulerAngles.x;
        if (angle > 180.0f)
            angle -= 360.0f;
        return Mathf.Deg2Rad * (angle);
    }
    public float GetWeaponAzimuth()
    {
        return Mathf.Deg2Rad * transform.eulerAngles.y;
    }
    public Vector3 GetWeaponPosition()
    {
        return transform.position;
    }

}
