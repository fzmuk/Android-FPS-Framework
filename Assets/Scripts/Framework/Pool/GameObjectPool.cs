using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    /// <summary>
    /// Class that implemants pools of GameObject type
    /// </summary>
    public class GameObjectPool: IPool<GameObject>
    {
        /// <summary>
        /// Object from wich pool is made
        /// </summary>
        public GameObject Prefab;

        /// <summary>
        /// Initial pool size
        /// </summary>
        public int InitialSize = 10;

        protected List<GameObject> allItems;

        protected List<GameObject> availableItems;

        /// <param name="prefab">Object from wich pool is made</param>
        public GameObjectPool(GameObject prefab)
        {
            Prefab = prefab;
            availableItems = new List<GameObject>();
            allItems = new List<GameObject>();
            Grow(InitialSize);
        }

        /// <param name="prefab">Object from wich pool is made</param>
        /// <param name="initialSize">Initial pool size</param>
        public GameObjectPool(GameObject prefab, int initialSize)
        {
            Prefab = prefab;
            availableItems = new List<GameObject>();
            allItems = new List<GameObject>();
            Grow(initialSize);
        }

        private void Add(GameObject gameObject)
        {
            if(!Contains(gameObject))
            {
                allItems.Add(gameObject);
                availableItems.Add(gameObject);
            }

        }

        /// <summary>
        /// Method that returns object into pool
        /// </summary>
        /// <param name="poolItem">Object to return</param>
        public void Return(GameObject poolItem)
        {
            if (Contains(poolItem) && !availableItems.Contains(poolItem))
            {
                poolItem.gameObject.SetActive(false);
                this.availableItems.Add(poolItem);
            }
        }

        /// <summary>
        /// The method retrieves the object from the pool
        /// </summary>
        /// <returns></returns>
        public GameObject Get() 
        {
            if (availableItems.Count == 0)
            {
                Grow(1);
            }

            GameObject poolItem = this.availableItems[0];
            poolItem.gameObject.SetActive(true);
            this.availableItems.RemoveAt(0);
            return poolItem;
        }

        /// <summary>
        /// The method increases initial number of objects in the pool
        /// </summary>
        /// <param name="amount"></param>
        public void Grow(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.Add(Factory());
            }
        }

        /// <summary>
        /// Method checks if object exists in the pool
        /// </summary>
        /// <param name="gameObject">Object to find</param>
        /// <returns></returns>
        public bool Contains(GameObject gameObject)
        {
            return allItems.Contains(gameObject);
        }

        private GameObject Factory()
        {
            GameObject poolItem = GameObject.Instantiate(Prefab);
            poolItem.name = Prefab.name;
            poolItem.SetActive(false);
            return poolItem;
        }

        /// <summary>
        ///  Method returns how many objects are available in the pool
        /// </summary>
        /// <returns></returns>
        public int GetAvailable ()
        {
            return availableItems.Count;
        }

        /// <summary>
        /// Method that returns size of the pool
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return allItems.Count;
        }
    }
}


