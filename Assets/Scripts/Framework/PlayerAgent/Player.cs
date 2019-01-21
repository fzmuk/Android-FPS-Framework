using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace PlayerAgent
{
    public class Player
    {

        public float Health = 0f;
        public float Armor = 0f;
        public NavMeshAgent Agent;

        private float startHealth = -Mathf.Infinity;
        private float startArmor = -Mathf.Infinity;
            

        public Player(NavMeshAgent agent)
        {
            Agent = agent;
        }

        public void ChangeStats(float amountToChange, Image progressBar, bool hp)
        {
            var fillAmount = 0f;

            if (startHealth == -Mathf.Infinity) startHealth = Health;
            if (startArmor == -Mathf.Infinity) startArmor = Armor;

            if (hp)
            {
                Health += amountToChange;
                fillAmount = Health / startHealth;
            }
            else
            {
                Armor += amountToChange;
                fillAmount = Armor / startArmor;
            }

            progressBar.fillAmount = fillAmount;
        }

        public void InitStats(Image[] progressBars)
        {
            foreach (Image progressBar in progressBars)
            {
                progressBar.fillAmount = 1;
            }
        }

    }
}
