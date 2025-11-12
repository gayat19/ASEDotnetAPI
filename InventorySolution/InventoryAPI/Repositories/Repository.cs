using InventoryAPI.Contexts;
using InventoryAPI.Interfaces;

namespace InventoryAPI.Repositories
{
    public abstract class Repository<K, T> : IRepository<K, T>
    {
        protected readonly InventoryContext _context;

        protected Repository(InventoryContext context)
        {
            _context = context;
        }
        public T Add(T item)
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            _context.Add(item);//Adds to the local DBSet
            _context.SaveChanges(); //Checks the status of every object in every set and writes DML queries accordingly
            return item;
        }

        public T Delete(K id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return item;
            }
            throw new Exception("Item not found");
        }

        public abstract ICollection<T> GetAll();


        public abstract T GetById(K key);
       

        public T Update(K key,T item)
        {
            var oldItem = GetById(key);
            if(oldItem != null)
            {
                _context.Entry(oldItem).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return oldItem;
            }
            throw new Exception("Item not found");
        }
    }
}
