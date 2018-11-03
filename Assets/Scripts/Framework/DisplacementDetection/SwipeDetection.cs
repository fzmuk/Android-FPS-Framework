using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DisplacementDetection
{
    public class SwipeDetection : MonoBehaviour, IDisplacement
    {
        public Vector2 Shift { get; private set; }
        public float MovmentRate { get; set; }

        private int fingerId;
        private bool inputSelected;

        void Start()
        {
            MovmentRate = 0.8f;
            inputSelected = false;
            Shift = new Vector2();
        }

        void Update()
        {
            Shift = new Vector2();

            foreach(var touch in Input.touches)
            {
                if(inputSelected)
                {
                    if(touch.fingerId == fingerId)
                    {
                        Shift = MovmentRate * touch.deltaPosition * touch.deltaTime;
                        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                        {
                            inputSelected = false;
                        }
                    }
                }
                else
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        inputSelected = true;
                        fingerId = touch.fingerId;
                    }
                }
                
            }
        }
    }
}
