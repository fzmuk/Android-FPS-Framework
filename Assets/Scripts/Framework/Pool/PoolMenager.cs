using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Pool
{
    public class PoolMenager
    {
        private Dictionary<String, Pool> pools;

        private static PoolMenager instance = null;

        public static PoolMenager Instance {
            get
            {
                if (instance == null)
                {
                    instance = new PoolMenager();
                }
                return instance;
            }
        }

        public PoolMenager()
        {
            //this.poolables = new List<Type>();
            pools = new Dictionary<String, Pool>();
        }

        public Pool CreatePool(GameObject prefab)
        {
            Pool pool = new Pool(prefab);
            pools.Add(prefab.name, pool);
            return pool;
        }

        public Pool CreatePool(GameObject prefab, int poolSize)
        {
            Pool pool = new Pool(prefab, poolSize);
            pools.Add(prefab.name, pool);
            return pool;
        }

        public GameObject GetFromPool(GameObject prefab)
        {
            if(pools.ContainsKey(prefab.name))
            {
                return GetFromPool(prefab.name);
            }
            else
            {
                return CreatePool(prefab).Get();
            }
        }

        public GameObject GetFromPool(string prefabName)
        {
            return pools[prefabName].Get();
        }

        public void ReturnToPool(GameObject gameObject)
        {
            if (pools.ContainsKey(gameObject.name))
            {
                pools[gameObject.name].Return(gameObject);
            }
        }
    }
}
