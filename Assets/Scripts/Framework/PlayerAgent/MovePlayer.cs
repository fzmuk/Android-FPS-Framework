using UnityEngine;
using DisplacementDetection;

namespace PlayerAgent
{
    /// <summary>
    /// Class that connects movement of the player with joystick.
    /// </summary>
    public class MovePlayer
    {
        //private GameObject player;
        private IDisplacement displacementInput;

        Player player;
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="player"></param>Object that represents player that is necessary to move.
        /// <param name="displacementInput"></param>Vector of the movement.
        public MovePlayer(Player player, IDisplacement displacementInput)
        {
            this.player = player;
            this.displacementInput = displacementInput;
        }
        /// <summary>
        /// Method that moves the player. It's necessary NavMashAgent component on the object.
        /// </summary>
        /// <param name="slow"></param>Value for which is possible to slow down the movement.
        public void PlayerMove(int slow)
        {
            var inputVector = displacementInput.Shift;
            var agent = player.Agent;
            Vector3 moveVector;

            if (inputVector.x != 0 && inputVector.y != 0)
            {
                moveVector = new Vector3(inputVector.x, 0, inputVector.y);
          
                agent.Move(agent.transform.TransformDirection(moveVector) * (agent.speed / slow)); //TODO 
                
            }                 
        }
    }
}