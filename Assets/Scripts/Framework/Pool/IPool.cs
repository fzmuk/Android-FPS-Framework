using UnityEngine;

namespace Pool
{
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