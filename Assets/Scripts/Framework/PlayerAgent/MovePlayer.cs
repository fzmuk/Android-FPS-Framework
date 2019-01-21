using UnityEngine;
using DisplacementDetection;

namespace PlayerAgent
{
    public class MovePlayer
    {

        //private GameObject player;
        private IDisplacement displacementInput;

        Player player;


        public MovePlayer(Player player, IDisplacement displacementInput)
        {
            this.player = player;
            this.displacementInput = displacementInput;
        }

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