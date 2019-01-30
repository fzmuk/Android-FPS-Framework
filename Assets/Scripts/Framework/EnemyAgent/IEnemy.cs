using UnityEngine;
using UnityEngine.UI;

namespace EnemyAgent
{
    /// <summary>
    /// Inteface that demands each enemy is NavMeshAgent, which means it contains that method.
    /// </summary>
    public interface IEnemy
    {
        float ChangeHealth(float AmountToChange);
    }
}
