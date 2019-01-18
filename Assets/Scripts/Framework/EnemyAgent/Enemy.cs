using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace EnemyAgent
{
    public class Enemy: IEnemy
    {
        public float DetectionDistance;
        public float Range; //problem
        public float Health;

        public NavMeshAgent Agent;

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

        public GameObject FindOponentByName(string name)
        {
            GameObject oponent = GameObject.Find(name);
            return oponent;
        }
        public GameObject FindOponentByTag(string tag)
        {
            GameObject oponent = GameObject.FindGameObjectWithTag(tag);
            return oponent;
        }


        private float startHealth = -Mathf.Infinity;

        public float ChangeHealth(float AmountToChange)
        {
            if (startHealth == -Mathf.Infinity) startHealth = Health;

            Health += AmountToChange;
            if (Health >= startHealth) return 1;

            return Health / startHealth;
        }

    }
}
