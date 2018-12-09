using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pool
{
    public abstract class Poolable
    {
        protected int poolInitialSize = 1;

        protected Pool<Poolable> pool;

        public void Reset() { }

        public void Initialize() { }

    }
}
