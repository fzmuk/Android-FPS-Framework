using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAgent
{
    /// <summary>
    /// Class that implements movement of the enemy on NavMesh and behaviour on detection of the FPS player.
    /// </summary>
    public class EnemyActions
    {
        IEnemy EnemyMove;
        /// <summary>
        /// Constructor of the class that receives object of the enemy class as parameter, 
        /// that alredy has NavMesh component necessary for managing enemy on NavMesh.
        /// </summary>
        /// <param name="enemy"></param>Object of the enemy class with which method of this class manages.
        public EnemyActions(IEnemy enemy) {
            EnemyMove = enemy;
        }
        /// <summary>
        /// Method that moves enemy to the FPS player and follows it through the scene.
        /// Once that enemy starts to follow the player, it will not stop 
        /// so this method returns true as indicator that enemy is striking the player.
        /// </summary>
        /// <param name="oponent"></param>Object that enemy should follow.
        public bool Follow(GameObject oponent)
        {
            EnemyMove.Agent.SetDestination(oponent.transform.position);

            if (EnemyMove.Agent.isPathStale) EnemyMove.Agent.SetDestination(oponent.transform.position);

            return true;            
        }
        /// <summary>
        /// Method that stops the enemy.
        /// Since enemy is no longer following FPS player, this method returns false.
        /// </summary>
        public bool Stop()
        {
            EnemyMove.Agent.ResetPath();
            return false;
        }
        /// <summary>
        /// Method that turns the enemy towards the target at the specified speed.
        /// </summary>
        /// <param name="oponent"></param>Object according to which an enemy is turning.
        /// <param name="RotationSpeed"></param>Speed of the rotation.
        public void LookAtPlayer(GameObject oponent, float RotationSpeed)
        {
            Vector3 direction = oponent.transform.position - EnemyMove.Agent.transform.position;
            Quaternion LookDirection = Quaternion.LookRotation(direction);
            Vector3 rotacija = Quaternion.Lerp(EnemyMove.Agent.transform.rotation, LookDirection, Time.deltaTime * RotationSpeed).eulerAngles;

            EnemyMove.Agent.transform.rotation = Quaternion.Euler(0f, rotacija.y, 0f);
        }       
    }
}
