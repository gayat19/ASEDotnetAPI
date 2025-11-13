using InventoryAPI.Models.Dtos;

namespace InventoryAPI.Interfaces
{
    public interface IProductService
    {
        public AddProductResponse CreateProduct(AddProductRequest? newProduct);
        public List<ProductDto> GetAllProducts(ProductSearchDto searchDto);
    }
}
