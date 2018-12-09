using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pool
{
    public abstract class Poolable
    {
        protected int poolInitialSize = 1;

        public Pool<Poolable> Pool { get; set; }

        public abstract void Reset();

        public abstract void Initialize();

    }
}
