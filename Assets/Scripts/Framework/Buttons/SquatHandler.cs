using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{

    public class SquatHandler : MonoBehaviour, IButtonHandler
    {

        // Use this for initialization
        void Start()
        {
            Button button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(Squat_Click);
 
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Squat_Click()
        {
            Debug.Log("Squat click: clicked");
        }

        public void Squat_Clicked()
        {

        }
    }


}