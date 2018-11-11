using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DisplacementDetection
{
    public class VirtualJoystick : IDisplacement
    {
        private Image joystickButton;
        private Image joystick;

        private Vector2 position;
        private Vector2 inputVector;
        private bool pressed;

        public VirtualJoystick(Image joystick, Image joystickButton)
        {
            this.joystick = joystick.GetComponent<Image>();
            this.joystickButton = joystickButton.GetComponent<Image>();
            pressed = false;
        }

        public Vector2 Shift 
        {
            get
            {
                if (!pressed) return Vector2.zero;

                inputVector = new Vector2(position.x * 2 - 1, position.y * 2 - 1); // poravnanje lijevo dolje
                inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            
                var x = inputVector.x * (joystick.rectTransform.sizeDelta.x / 3);
                var y = inputVector.y * (joystick.rectTransform.sizeDelta.y / 3);

                return new Vector2(x, y);
            }

        }

        public bool JoystickHit(PointerEventData ped)
        {
            var outerJoysticIsHit = RectTransformUtility
                .ScreenPointToLocalPointInRectangle(
                    joystick.rectTransform,
                    ped.position,
                    ped.pressEventCamera,
                    out position
                );

            position.x = (position.x / joystick.rectTransform.sizeDelta.x); //vrijednost od 0-1 gdje se nalazimo na velikoj kruznici
            position.y = (position.y / joystick.rectTransform.sizeDelta.y);

            return outerJoysticIsHit;
        }

 
        public void PressedJoystick()
        {
            pressed = true;
        }

        public void ReleaseJoystick()
        {
            pressed = false;
            joystickButton.rectTransform.anchoredPosition = Vector3.zero;
        }

        public void MoveJoistickButton()
        {
            joystickButton.rectTransform.anchoredPosition = Shift;
        }
    }
}
