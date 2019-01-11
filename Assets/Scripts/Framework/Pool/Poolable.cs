using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Pool
{
    public abstract class Poolable : MonoBehaviour
    {
        protected int poolInitialSize = 10;

        //public Pool<Poolable> Pool { get; set; }

        public virtual void Initialize() { }

        public virtual void Reset() { }
    }
}
