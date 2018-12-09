using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class Enemy
    {
        private float detectionDistance;
        private float range;

        public NavMeshAgent Agent;        

        public Enemy(NavMeshAgent agent)
        {
            Agent = agent;
        }

        public float StopingDistance
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

        public float DetectionDistance
        {
            get
            {
                return detectionDistance;
            }
            set
            {
                detectionDistance = value;
            }
        }
        //health, armor
        public float Range;

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

    }
}
