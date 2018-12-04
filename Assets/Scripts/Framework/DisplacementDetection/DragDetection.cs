using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DisplacementDetection
{
    public class DragDetection : IDisplacement
    {
        public Vector2 Shift
        {
            get
            {
                var tmpShift = shift;
                shift = Vector2.zero;
                return tmpShift;
            }
        }


        public float MovementRate { get; set; }

        private Vector2 shift;
        private int pointerId;
        private bool inputSelected;

        public DragDetection()
        {
            MovementRate = 1.0f;
            inputSelected = false;
            shift = Vector2.zero;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!inputSelected)
            {
                inputSelected = true;
                pointerId = eventData.pointerId;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (inputSelected && eventData.pointerId == pointerId)
            {
                shift += MovementRate * eventData.delta;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerId == pointerId)
            {
                inputSelected = false;
            }
        }
    }
}
