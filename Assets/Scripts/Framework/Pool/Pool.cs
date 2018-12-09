using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class Pool<T> where T : Poolable
    {
        //all items in pool
        protected List<T> allItems;

        protected List<T> availableItems;

        protected Func<T> factory;

        public Pool () : this(null) {}

        public Pool(Func<T> factory)
        {
            if (factory != null)
            {
                this.factory = factory;
            }
            else
            {
                this.factory = SimpleFactory;
            }

            this.availableItems = new List<T>();
            this.allItems = new List<T>();
        }

        public void Add(T item)
        {
            this.allItems.Add(item);
            this.availableItems.Add(item);
        }

        public void Return(T item)
        {
            if(this.Contains(item) && !this.availableItems.Contains(item))
            {
                this.availableItems.Add(item);
            }
        }

        public T Get() 
        {
            if(this.availableItems.Count > 0)
            {
                T poolItem = this.availableItems[0];
                poolItem.Reset();
                this.availableItems.RemoveAt(0);
                return poolItem;
            }

            Grow(1);
            return this.Get();
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


