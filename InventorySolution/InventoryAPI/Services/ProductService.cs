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

        public List<ProductDto> GetAllProducts(ProductSearchDto? searchDto)
        {
            var products = _productRepository.GetAll().ToList();
            if (searchDto == null)
               return _mapper.Map<List<ProductDto>>(products);
            
            if (searchDto.Title != null)
            products = products
                .Where(p => p.Title==searchDto.Title).ToList();

            if(searchDto.PriceRange != null && searchDto.PriceRange.Min<searchDto.PriceRange.Max)
                    products = products
                        .Where(p => p.Price >= searchDto.PriceRange.Min && p.Price<= searchDto.PriceRange.Max).ToList();

            if(searchDto.IsInStock != null)
                products = products
                    .Where(p => searchDto.IsInStock == true ? p.StockInHand>0 : p.StockInHand==0).ToList();

            if(searchDto.SortOrder == 1)
            {
                products = products
                    .OrderBy(p => p.Price).ToList();
                return _mapper.Map<List<ProductDto>>(products);
            }
            else
            {
                products = products
                    .OrderByDescending(p => p.Price).ToList();
                return _mapper.Map<List<ProductDto>>(products);
            }
        }
    }
}
