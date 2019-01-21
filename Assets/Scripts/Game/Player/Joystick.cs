using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DisplacementDetection;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    public VirtualJoystick virtualJoystick;

    private Image joystickButton;
    private Image joystick;

    private void Start()
    {
        joystick = GetComponent<Image>();
        joystickButton = transform.GetChild(0).GetComponent<Image>();

        virtualJoystick = new VirtualJoystick(joystick, joystickButton);
        
    }

    public void OnDrag(PointerEventData ped)
    {
        if (virtualJoystick.JoystickHit(ped))
        {
            virtualJoystick.MoveJoistickButton();
        }
    }

    public void OnPointerDown(PointerEventData ped)
    {
        virtualJoystick.PressedJoystick();
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        virtualJoystick.ReleaseJoystick();
    }

   
}

