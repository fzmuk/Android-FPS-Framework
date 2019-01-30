using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace EnemyAgent
{
    /// <summary>
    /// Inteface that demands each enemy is NavMeshAgent, which means it contains that method.
    /// </summary>
    public interface IEnemy
    {
        NavMeshAgent Agent { get; set; }
    }
}
