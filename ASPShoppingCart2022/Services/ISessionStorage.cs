namespace ASPShoppingCart2022.Services
{
    public interface ISessionStorage<T>
    {
        public T LoadOrCreate(string key);
        public void Save(string key, T data);
    }
}