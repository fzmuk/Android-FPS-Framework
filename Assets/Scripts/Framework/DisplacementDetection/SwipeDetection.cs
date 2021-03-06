﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DisplacementDetection
{
    /// <summary>
    ///  Class intended for the detection of the movement through touch screen. 
    ///  During development it's also enabled to use the mouse.
    ///  It can be added using method AddComponent<SwipeDetection> on the object that is being added.
    /// </summary>
    public class SwipeDetection : MonoBehaviour, IDisplacement
    {
        public Vector2 Shift { get; private set; }

        public float MovmentRate { get; set; }

        private int fingerId;
        private bool inputSelected;

#if UNITY_EDITOR
        /// <summary>
        /// Used for mouse debugging in Unity editor.
        /// </summary>
        public Vector3 MouseShift;
        bool mouseDrag = false;
#endif
        private void Start()
        {
            MovmentRate = 1f;
            inputSelected = false;
            Shift = new Vector2();
        }
        private void Update()
        {
            Shift = new Vector2();

            foreach (var touch in Input.touches)
            {
                if (inputSelected)
                {
                    if (touch.fingerId == fingerId)
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
                        if(!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                        {
                            inputSelected = true;
                            fingerId = touch.fingerId;
                        }
                    }
                }
            }
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                MouseShift = Input.mousePosition;
                mouseDrag = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                mouseDrag = false;
            }
            if (mouseDrag)
            {
                Shift = 0.1f * (Input.mousePosition - MouseShift);
                MouseShift = Input.mousePosition;
            }
#endif
        }
    }
}
