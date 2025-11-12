using AutoMapper;
using InventoryAPI.Interfaces;
using InventoryAPI.Models;
using InventoryAPI.Models.Dtos;
using InventoryAPI.Repositories;

namespace InventoryAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int, Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<int,Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public AddProductResponse CreateProduct(AddProductRequest newProduct)
        {
            if(newProduct == null)
                throw new ArgumentNullException(nameof(newProduct));
            if(newProduct.Price<0 || newProduct.StockInHand<0)
                throw new ArgumentException("Price or StockInHand cannot be negative");
            var productEntity = _mapper.Map<Product>(newProduct);
            productEntity.IsAvailable = true;
            var createdProduct = _productRepository.Add(productEntity);
            return new AddProductResponse
            {
                NewProductId = createdProduct.Id
            };

        }
    }
}
