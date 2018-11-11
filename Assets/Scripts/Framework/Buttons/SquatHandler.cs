using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buttons
{

    public class SquatHandler : MonoBehaviour, IButtonHandler
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Squat_Click()
        {
            Debug.Log("Squat click: clicked");
        }
    }


}