using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class Enemy
    {
        public NavMeshAgent Agent;
        private float detectionDistance;
        private int speed;
        private int acceleration;
        private int stopingDistance;

        private float range;

        public Enemy(NavMeshAgent agent)
        {
            Agent = agent;
        }

        public int StopingDistance
        {
            get
            {
                return stopingDistance;
            }
            set
            {
                Agent.stoppingDistance = value;
            }
        }

        public int Acceleration
        {
            get
            {
                return acceleration;
            }
            set
            {
                Agent.acceleration = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
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
