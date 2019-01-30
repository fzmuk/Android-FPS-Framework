using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Pool
{
    /// <summary>
    /// Singleton class that stores different types of pools
    /// </summary>
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

        private PoolMenager()
        {
            pools = new Dictionary<String, IPool<GameObject>>();
        }

        /// <summary>
        /// Method for creating pools.
        /// </summary>
        /// <param name="prefab"> Object that will be pooled </param>
        /// <returns></returns>
        public IPool<GameObject> CreatePool(GameObject prefab)
        {
            IPool<GameObject> pool = new GameObjectPool(prefab);
            pools.Add(prefab.name, pool);
            return pool;
        }

        /// <summary>
        /// Method for creating pools.
        /// </summary>
        /// <param name="prefab">Object that will be pooled</param>
        /// <param name="poolSize">Size of the pool</param>
        /// <returns></returns>
        public IPool<GameObject> CreatePool(GameObject prefab, int poolSize)
        {
            IPool<GameObject> pool = new GameObjectPool(prefab, poolSize);
            pools.Add(prefab.name, pool);
            return pool;
        }

        /// <summary>
        /// Method for retrieving the pool
        /// </summary>
        /// <param name="prefab">Object that is pooled</param>
        /// <returns></returns>
        public IPool<GameObject> GetPool(GameObject prefab)
        {
            return GetPool(prefab.name);
        }

        /// <summary>
        /// Method for retrieving the pool
        /// </summary>
        /// <param name="name">Name of pooled object</param>
        /// <returns></returns>
        public IPool<GameObject> GetPool(string name)
        {
            return pools[name];
        }

        /// <summary>
        /// Method for retrieving objects from the pool
        /// </summary>
        /// <param name="prefab">Object that is poole</param>
        /// <returns></returns>
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

        /// <summary>
        /// Method for retrieving objects from the pool
        /// </summary>
        /// <param name="prefabName">Name of pooled object</param>
        /// <returns></returns>
        public GameObject GetFromPool(string prefabName)
        {
            return pools[prefabName].Get();
        }

        /// <summary>
        /// Method for returnig objects into pool
        /// </summary>
        /// <param name="gameObject"></param>
        public void ReturnToPool(GameObject gameObject)
        {
            if (pools.ContainsKey(gameObject.name))
            {
                pools[gameObject.name].Return(gameObject);
            }
        }
    }
}
