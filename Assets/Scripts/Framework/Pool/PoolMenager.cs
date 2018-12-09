using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pool
{
    public class PoolMenager
    {
        public List<Poolable> poolables;

        private Dictionary<Poolable, Pool<Poolable>> pools;

        private PoolMenager instance = null;

        public PoolMenager Instance { get
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
            this.poolables = new List<Poolable>();
            this.pools = new Dictionary<Poolable, Pool<Poolable>>();
        }

        private Poolable GetPoolable(Poolable prefab)
        {
            if(!poolables.Contains(prefab))
            {
                this.pools.Add(prefab, new Pool<Poolable>());
            }

            return this.pools[prefab].Get();
        }

        private void Return(Poolable item)
        {
            item.Pool.Return(item);
        }
    }
}
