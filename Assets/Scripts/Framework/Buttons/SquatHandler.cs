using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class SquatHandler : MonoBehaviour, IButtonHandler
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
        void OnPointerDown()
        {
            Debug.Log("Pointer down SQUAT");
        }
        /// <summary>
        /// Temporary just show text in debug log.
        /// </summary>
        public void Click()
        {
            Debug.Log("Clicked SQUAT");
        }
        public void Pressed()
        {

        }
        public void Released()
        {

        }
    }
}