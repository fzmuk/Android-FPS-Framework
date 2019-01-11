using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pool
{
    public class PoolMenager
    {
        public List<Type> poolables;

        private Dictionary<Type, Pool<Poolable>> pools;

        private PoolMenager instance = null;

        public PoolMenager Instance {
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
            this.poolables = new List<Type>();
            this.pools = new Dictionary<Type, Pool<Poolable>>();
        }


        
        private Poolable GetPoolable<T>() where T: Poolable
        {
            if(!poolables.Contains(typeof(T)))
            {
                poolables.Add(typeof(T));
                pools.Add(typeof(T), new Pool<Poolable>());
            }

            return this.pools[typeof(T)].Get();
        }

        private void Return(Poolable item)
        {
            item.Pool.Return(item);
        }
    }
}
