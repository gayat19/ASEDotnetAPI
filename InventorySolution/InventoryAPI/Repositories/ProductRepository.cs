using InventoryAPI.Contexts;
using InventoryAPI.Models;
using System.Diagnostics.CodeAnalysis;

namespace InventoryAPI.Repositories
{
    public class ProductRepository : Repository<int, Product>
    {
        public ProductRepository(InventoryContext context) : base(context)
        {
            
        }
        public override ICollection<Product> GetAll()
        {
            var products = _context.Products;
            if(products.Count()==0)
                throw new Exception("No products found");
            return products.ToList();
        }
        
        public override Product GetById(int key)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == key);
            return product ?? throw new Exception("Product not found");
        }
    }
}
