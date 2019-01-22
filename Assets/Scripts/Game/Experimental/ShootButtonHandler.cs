using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Framework.Experimental;

namespace Assets.Scripts.Game.Experimental
{
    internal class ShootButtonHandler : MonoBehaviour, Buttons.IButtonHandler
    {
        protected IShootButtonFramework frameworkButtonHandler;
        protected IBallisticFramework ballistics;
        protected IBallisticGauge gauge;
        protected IBallisticCalculation calculation;

        protected GameObject dummyProjectile;
        public WeaponHandler weaponHandler;

        

        void Start()
        {
            //game object needs MonoBehaviour class, Button needs Buttons namespace
            //Start() is method in MonoBehaviour
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Click);

            frameworkButtonHandler = new ShootButtonFramework();
            weaponHandler = GameObject.FindObjectOfType(typeof(WeaponHandler)) as WeaponHandler;

            ballistics = new BallisticFramework();
            gauge = new BallisticGauge();
        }
        //updated for each frame
        void Update()
        {
            ballistics.OnUpdate(); 
        }
        //calls for button click
        public void Click()
        {
            if (frameworkButtonHandler != null)
            {
                frameworkButtonHandler.OnClick();


            }
          
            /*
            if (weaponHandler!=null)
            {
                float elevation = weaponHandler.GetWeaponElevation();
                float azimuth = weaponHandler.GetWeaponAzimuth();
                Vector3 position = weaponHandler.GetWeaponPosition();
                if (ballistics != null)
                    ballistics.Init(azimuth,elevation,position);
            } 
            */
            if(weaponHandler != null)
            {
                Transform transform = weaponHandler.getWeaponTransform();
                if (ballistics != null)
                {
                    //test
                    dummyProjectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    dummyProjectile.transform.SetPositionAndRotation(weaponHandler.getWeaponTransform().position, weaponHandler.getWeaponTransform().rotation);
                    dummyProjectile.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                    double gamescale = 0.05;

                    calculation = new BallisticCalcBullet(0.03, 9.81, 0.5, 1.23 / gamescale, 0.00006, gamescale); //m, g, Cx, ro, A
                    ballistics.Init(dummyProjectile, calculation, weaponHandler.getWeaponTransform(), 600.0);

                    //calculation = new BallisticCalcGrenade(0.3, 9.81, 0.7, 1.23, 0.0025, gamescale); //m, g, Cx, ro, A
                    //ballistics.Init(dummyProjectile, calculation, weaponHandler.getWeaponTransform(),20.0);

                   

                }

                //gauge test
                if (gauge != null)
                {
                    double gamescale = 0.05;

                    calculation = new BallisticCalcBullet(0.03, 9.81, 0.5, 1.23 / gamescale, 0.00006, gamescale); //m, g, Cx, ro, A
                    gauge.Init(null, calculation, weaponHandler.getWeaponTransform(), 600.0);

                    //calculation = new BallisticCalcGrenade(0.3, 9.81, 0.7, 1.23, 0.0025, gamescale); //m, g, Cx, ro, A
                    //gauge.Init(calculation, 20.0, 45.0);

                    double range = gauge.CalculateRange();

                    double elevation = 360.0f - weaponHandler.getWeaponTransform().eulerAngles.x;
                    if (elevation > 180.0f)
                        elevation -= 360.0f;
                    Debug.Log("Projectile range: " + range+ ", at elevation: "+ elevation);
                }

                //gauge test2
                if (gauge != null)
                {
                    double gamescale = 0.05;
                    calculation = new BallisticCalcBullet(0.03, 9.81, 0.5, 1.23 / gamescale, 0.00006, gamescale); //m, g, Cx, ro, A
                    gauge.Init(calculation, 600.0, weaponHandler.getWeaponTransform().position.y, 45.0);

                    //calculation = new BallisticCalcGrenade(0.3, 9.81, 0.7, 1.23, 0.0025, gamescale); //m, g, Cx, ro, A
                    //gauge.Init(calculation, 20.0, 45.0);

                    double elevation = 0.0;
                    double range = gauge.CalculateMaximumRange(ref elevation);
                    Debug.Log("Projectile max. range: " + range);
                }

            }
        }

        public void Pressed()
        {
            throw new NotImplementedException();
        }

        public void Released()
        {
            throw new NotImplementedException();
        }
    }
}
