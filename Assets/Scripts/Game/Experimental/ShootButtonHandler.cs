using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Framework.Experimental;
using Pool;

namespace Assets.Scripts.Game.Experimental
{
    internal class ShootButtonHandler : MonoBehaviour, Buttons.IButtonHandler
    {
        protected IShootButtonFramework frameworkButtonHandler;
        protected IBallisticFramework ballistics;
        protected IBallisticCalculation calculation;
        protected GameObject bullet;
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
                    PoolMenager poolManager = PoolMenager.Instance;
                    bullet = poolManager.GetFromPool("Bullet");
                    bullet.transform.SetPositionAndRotation(weaponHandler.getWeaponTransform().position, weaponHandler.getWeaponTransform().rotation);
                    bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);


                    //temporaly 
                    //dummyProjectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    //dummyProjectile.transform.SetPositionAndRotation(weaponHandler.getWeaponTransform().position, weaponHandler.getWeaponTransform().rotation);
                    //dummyProjectile.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                    double gamescale = 0.05;

                    //calculation = new BallisticCalcBullet(0.01, 9.81, 0.5, 1.23 / gamescale, 0.0001, gamescale); //m, g, Cx, ro, A
                    //ballistics.Init(dummyProjectile, calculation, weaponHandler.getWeaponTransform(), 600.0);

                    calculation = new BallisticCalcGrenade(0.3, 9.81, 0.7, 1.23, 0.0025, gamescale); //m, g, Cx, ro, A
                    ballistics.Init(bullet, calculation, weaponHandler.getWeaponTransform(),20.0);
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
