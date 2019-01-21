using UnityEngine;
using UnityEngine.UI;

namespace EnemyAgent
{
    public interface IEnemy
    {
        float ChangeHealth(float AmountToChange);
    }
}
