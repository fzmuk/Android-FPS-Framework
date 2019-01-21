using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class GameObjectPool: IPool<GameObject>
    {
        public GameObject Prefab;

        public int InitialSize = 10;

        protected List<GameObject> allItems;

        protected List<GameObject> availableItems;

        public GameObjectPool(GameObject prefab)
        {
            Prefab = prefab;
            availableItems = new List<GameObject>();
            allItems = new List<GameObject>();
            Grow(InitialSize);
        }

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

        public void Return(GameObject poolItem)
        {
            if (Contains(poolItem) && !availableItems.Contains(poolItem))
            {
                poolItem.gameObject.SetActive(false);
                this.availableItems.Add(poolItem);
            }
        }

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

        public void Grow(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.Add(Factory());
            }
        }

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
    }
}


