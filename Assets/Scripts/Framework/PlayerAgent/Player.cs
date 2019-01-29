using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace PlayerAgent
{
    /// <summary>
    /// Class that implements FPS player with it's statistics (life and armor).
    /// </summary> 
    public class Player
    {

        public float Health = 0f;
        public float Armor = 0f;
        public NavMeshAgent Agent;

        private float startHealth = -Mathf.Infinity;
        private float startArmor = -Mathf.Infinity;
            
        /// <summary>
        /// Constructor of the class that receives NavMeshAgent component as parameter,
        /// that saves into propertie Agent so through other scripts it is possible
        /// to manage attributes of the player movement on NavMesh.
        /// </summary>
        /// <param name="agent"></param>NavMesh component necessarie so player can move on NavMesh.
        public Player(NavMeshAgent agent)
        {
            Agent = agent;
        }
        /// <summary>
        /// Method that manages with exchange of the graphic elements for displaying life and armour,
        /// it saves new state of the player. It the player is hit, amountToChange will be negative number
        /// for any change of live or armour, positive value increases last state for forwarded value.
        /// Because life is atribute that determines game, setting last attribute true will manage with 
        /// exchaning life while opposite changes apply on armour.
        /// </summary>
        /// <param name="amountToChange"></param>Amount for which some of the attribute of the statistics is neccesary to change.
        /// <param name="progressBar"></param>Graphic element of the intreface on which the result is displayed.
        /// <param name="hp"></param>If it's true modification is execute on attribute Health, if it's opposite on Armor.
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
        /// <summary>
        /// Method that initializes graphical interface on the way that shows maximum values in percentages.
        /// As parameter it receives array of the graphic elements in a case that user wants to show 
        /// both attributes of the statistic.
        /// </summary>
        /// <param name="progressBars"></param>Array of the graphic elements that is neccesary to initialize.
        public void InitStats(Image[] progressBars)
        {
            foreach (Image progressBar in progressBars)
            {
                progressBar.fillAmount = 1;
            }
        }

    }
}
