using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace EnemyAgent
{
    /// <summary> 
    /// Class that implements NavMeshAgent enemy with it's statistics.
    /// </summary>
    public class Enemy: IEnemy
    {
        public float DetectionDistance;
        public float Range; //problem
        public float Health;

        public NavMeshAgent Agent;
        /// <summary>
        /// Constructor of the class that receives NavMeshAgent component as parameter and
        /// saves into propertie Agent, so through other scripts it's possible to manage
        /// attributes of movement and move enemy on NavMesh.
        /// </summary>
        /// <param name="agent"></param>NavMeshAgent component necessary so enemy can move on NavMesh.
        public NavMeshAgent Agent { get; set; }

        public Enemy(NavMeshAgent agent)
        {
            Agent = agent;
        }
        public float StoppingDistance
        {
            get
            {
                return Agent.stoppingDistance;
            }
            set
            {
                Agent.stoppingDistance = value;
            }
        }
        public float Acceleration
        {
            get
            {
                return Agent.acceleration;
            }
            set
            {
                Agent.acceleration = value;
            }
        }
        public float Speed
        {
            get
            {
                return Agent.speed;
            }
            set
            {
                Agent.speed = value;
            }
        }
        /// <summary>
        /// Method for finding FPS player through the name of the object, and returns the found object.
        /// </summary>
        /// <param name="name"></param>Name of the object.
        /// <returns></returns>
        public GameObject FindOponentByName(string name)
        {
            GameObject oponent = GameObject.Find(name);
            return oponent;
        }
        /// <summary>
        /// Method for finding FPS player through the name of the tag of the object, and returns the found object.
        /// </summary>
        /// <param name="tag"></param>Name of the tag of the object.
        /// <returns></returns>
        public GameObject FindOponentByTag(string tag)
        {
            GameObject oponent = GameObject.FindGameObjectWithTag(tag);
            return oponent;
        }
        /// <summary>
        /// Implementation of the interface. 
        /// Method manages with points of life of the enemy and saves the changes in the attribute Health. 
        /// Value which is entered if the enemy is stricken has negative sign.
        /// </summary>
        private float startHealth = -Mathf.Infinity;

        public float ChangeHealth(float amountToChange)
        {
            if (startHealth == -Mathf.Infinity) startHealth = Health;

            Health += amountToChange;
            if (Health >= startHealth) return 1;

            return Health / startHealth;
        }
    }
}
