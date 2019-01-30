using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DisplacementDetection
{
    /// <summary>
    /// Class that implements functionality of the virtual joystick.
    /// </summary>
    public class VirtualJoystick : IDisplacement
    {
        private Image joystickButton;
        private Image joystick;

        private Vector2 position;
        private Vector2 inputVector;
        private bool pressed;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="joystick"></param>Base of the joystick. Usually bigger circular.
        /// <param name="joystickButton"></param>Button of the joystick. Usually smaller circular.
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
        /// <summary>
        /// Method that returns true if the area of the joystick is clicked.
        /// </summary>
        /// <param name="ped"></param>Data about event, when using mouse or touch.
        /// <returns></returns>
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
        /// <summary>
        /// Method checks if joystick is used.
        /// </summary>
        public void PressedJoystick()
        {
            pressed = true;
        }
        /// <summary>
        /// Method releases the usage of joystick and returns smaller circular in start position.
        /// </summary>
        public void ReleaseJoystick()
        {
            pressed = false;
            joystickButton.rectTransform.anchoredPosition = Vector3.zero;
        }
        /// <summary>
        /// Method that moves smaller circular inside bigger one.
        /// </summary>
        public void MoveJoistickButton()
        {
            joystickButton.rectTransform.anchoredPosition = Shift;
        }
    }
}
