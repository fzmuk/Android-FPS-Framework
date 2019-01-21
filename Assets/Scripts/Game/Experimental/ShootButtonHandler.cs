using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Framework.Experimental;
using Pool;
using System.Collections;

namespace Assets.Scripts.Game.Experimental
{
    internal class ShootButtonHandler : MonoBehaviour, Buttons.IButtonHandler
    {
        protected IShootButtonFramework frameworkButtonHandler;
        protected GameObject bullet;
        private Transform weaponTransform;

        public WeaponHandler weaponHandler;

        PoolMenager poolManager = PoolMenager.Instance;

        void Start()
        {
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Click);

            frameworkButtonHandler = new ShootButtonFramework();
            weaponHandler = GameObject.Find("FPS_Character_prefab").GetComponentInChildren<WeaponHandler>() as WeaponHandler;
            weaponTransform = weaponHandler.getWeaponTransform();

        }

        //calls for button click
        public void Click()
        {
            if (frameworkButtonHandler != null)
            {
                frameworkButtonHandler.OnClick();
            }

            if (weaponHandler != null)
            {

                bullet = poolManager.GetFromPool("Bullet");
                bullet.transform.SetPositionAndRotation(weaponHandler.getWeaponTransform().position, weaponHandler.getWeaponTransform().rotation);
                bullet.GetComponent<BulletBallistics>().Init(weaponTransform, poolManager);

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