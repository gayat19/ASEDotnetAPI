using InventoryAPI.Models;

namespace InventoryAPI.Interfaces
{
    public interface IRepository<K,T>
    {
        public ICollection<T> GetAll();

        public T GetById(K key);
        public T Add(T item);
        public T Update(K key,T item);
        public T Delete(K id);
    }
}
