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

        public void Follow(GameObject oponent)
        {
            if(EnemyMove.Agent.remainingDistance != EnemyMove.Agent.stoppingDistance || EnemyMove.Agent.isPathStale)
                EnemyMove.Agent.SetDestination(oponent.transform.position);            
        }
        
    }
}
