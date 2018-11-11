using UnityEngine;
using UnityEngine.AI;
using DisplacementDetection;

namespace PlayerMovement
{
    public class MovePlayer
    {

        private GameObject player;
        private IDisplacement displacementInput;  

        public MovePlayer (GameObject player, IDisplacement displacementInput)
        {
            this.player = player;
            this.displacementInput = displacementInput;
        }

        public void PlayerMove(int slow)
        {
            var inputVector = displacementInput.Shift;
            var agent = player.GetComponent<NavMeshAgent>();
            Vector3 moveVector;
            if (inputVector.x != 0 && inputVector.y != 0)
            {
                moveVector = new Vector3(inputVector.x, 0, inputVector.y);
                agent.Move(moveVector*(agent.speed/ slow));
            }
                 
        }

    }
}
