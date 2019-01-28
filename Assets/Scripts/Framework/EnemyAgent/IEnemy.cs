using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace EnemyAgent
{
    public interface IEnemy
    {
        NavMeshAgent Agent { get; set; }
    }
}
