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
        public WeaponHandler weaponHandler;

        void Start()
        {
            //game object needs MonoBehaviour class, Button needs Buttons namespace
            //Start() is method in MonoBehaviour
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Click);

            frameworkButtonHandler = new ShootButtonFramework();
            weaponHandler = GameObject.FindObjectOfType(typeof(WeaponHandler)) as WeaponHandler;
            ballistics = new BallisticFramework(0.01f, 600.0f, 0.368f);
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
                frameworkButtonHandler.OnClick();
          
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
                    ballistics.Init(transform);
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
