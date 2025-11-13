using InventoryAPI.Interfaces;
using InventoryAPI.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles ="admin")]
        [HttpPost]
        public ActionResult CreateNewProduct([FromBody] AddProductRequest product)
        {
            try
            {
                var productResult = _productService.CreateProduct(product);
                return Created("", productResult);
            }
            catch(ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize]
        [HttpPost("GetProducts")]
        public ActionResult GetAllProducts([FromBody] ProductSearchDto? searchDto)
        {
            try
            {
                var products = _productService.GetAllProducts(searchDto);
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
