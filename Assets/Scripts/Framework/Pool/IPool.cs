using UnityEngine;

namespace Pool
{
    /// <summary>
    /// Interface for creating pools.
    /// </summary>
    /// <typeparam name="T"> Type of object in pool </typeparam>
    public interface IPool<T>
    {
        T Get();
        void Grow(int amount);
        bool Contains(T item);
        void Return(T item);
        int GetAvailable();
        int GetSize();
    }
}