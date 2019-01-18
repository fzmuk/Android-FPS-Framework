using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyAgent
{
    public class EnemyActions
    {
        Enemy EnemyMove;

        public EnemyActions(Enemy enemy) {
            EnemyMove = enemy;
        }

        public bool Follow(GameObject oponent)
        {
            if (EnemyMove.Agent.remainingDistance != EnemyMove.Agent.stoppingDistance || EnemyMove.Agent.isPathStale) //fix
            {
                EnemyMove.Agent.SetDestination(oponent.transform.position);
                return true;
            }

            return false;                  
        }

        public void LookAtPlayer(GameObject oponent, float RotationSpeed)
        {
            Vector3 direction = oponent.transform.position - EnemyMove.Agent.transform.position;
            Quaternion LookDirection = Quaternion.LookRotation(direction);
            Vector3 rotacija = Quaternion.Lerp(EnemyMove.Agent.transform.rotation, LookDirection, Time.deltaTime * RotationSpeed).eulerAngles;

            EnemyMove.Agent.transform.rotation = Quaternion.Euler(0f, rotacija.y, 0f);
        }
        
    }
}
