namespace Pool
{
    public interface IPool<T>
    {
         T Get();
        void Grow(int amount);
        bool Contains(GameObject gameObject);
    }
}