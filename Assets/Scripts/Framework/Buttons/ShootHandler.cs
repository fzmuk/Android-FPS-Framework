using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class ShootHandler : MonoBehaviour, IButtonHandler
    {
        /// <summary>
        /// Used for initialization.
        /// </summary>
        void Start()
        {
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Click);
        }
        /// <summary>
        /// Called once per frame.
        /// </summary>
        void Update()
        {

        }
        /// <summary>
        /// Temporary just show text in debug log.
        /// </summary>
        public void Click()
        {
            Debug.Log("Clicked SHOOT");
        }
        public void Pressed()
        {

        }
        public void Released()
        {

        }
    }
}