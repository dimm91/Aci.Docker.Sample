using Microsoft.AspNetCore.Mvc;
using Product.Web.Api.Services;

namespace Product.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getProducts")]
        public async Task<IEnumerable<Product.Sql.Context.Models.Product>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("getProduct/{id}")]
        public async Task<Product.Sql.Context.Models.Product?> GetProduct(Guid id)
        {
            return await _productService.GetProduct(id);
        }
    }
}
