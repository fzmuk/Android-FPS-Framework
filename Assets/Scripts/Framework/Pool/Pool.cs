using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class Pool<T> where T : Poolable
    {
        protected List<T> allItems;

        protected List<T> availableItems;

        protected Func<T> factory;

        public Pool()
        {
            this.factory = SimpleFactory;
            this.availableItems = new List<T>();
            this.allItems = new List<T>();
        }

        public Pool (Func<T> factory) {
            this.factory = factory;
            this.availableItems = new List<T>();
            this.allItems = new List<T>();
        }

        private void Add(T item)
        {
            // item.Pool = this;
            this.allItems.Add(item);
            this.availableItems.Add(item);
        }

        public void Return(T item)
        {
            if(this.Contains(item) && !this.availableItems.Contains(item))
            {
                item.gameObject.SetActive(false);
                this.availableItems.Add(item);
            }
        }

        public T Get() 
        {
            if (this.availableItems.Count == 0)
            {
                Grow(1);
            }

            T poolItem = this.availableItems[0];
            poolItem.Reset();
            poolItem.gameObject.SetActive(true);
            this.availableItems.RemoveAt(0);
            return poolItem;
        }

        public void Grow(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                T newItem = this.factory();
                newItem.Initialize();
                this.Add(newItem);
            }
        }

        public bool Contains(T item)
        {
            return this.allItems.Contains(item);
        }

        private T SimpleFactory()
        {
            return default(T);
        }
    }
}


