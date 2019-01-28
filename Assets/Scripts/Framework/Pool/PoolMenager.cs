using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Pool
{
    public class PoolMenager
    {
        private Dictionary<String, IPool<GameObject>> pools;

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
            pools = new Dictionary<String, IPool<GameObject>>();
        }

        public IPool<GameObject> CreatePool(GameObject prefab)
        {
            IPool<GameObject> pool = new GameObjectPool(prefab);
            pools.Add(prefab.name, pool);
            return pool;
        }

        public IPool<GameObject> CreatePool(GameObject prefab, int poolSize)
        {
            IPool<GameObject> pool = new GameObjectPool(prefab, poolSize);
            pools.Add(prefab.name, pool);
            return pool;
        }

        public IPool<GameObject> GetPool(GameObject prefab)
        {
            return GetPool(prefab.name);
        }

        public IPool<GameObject> GetPool(string name)
        {
            return pools[name];
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
