using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement:Enemy
    {
        public EnemyMovement(NavMeshAgent agent) : base(agent)
        {
        }

        public void Follow(GameObject oponent)
        {
            if(this.Agent.remainingDistance == 0 || this.Agent.isPathStale)
                this.Agent.SetDestination(oponent.transform.position);            
        }

      
    }
}
