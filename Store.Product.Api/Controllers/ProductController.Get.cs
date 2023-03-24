using Microsoft.AspNetCore.Mvc;
using Store.Product.Api.Service.Contract;

namespace Store.Product.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public partial class ProductController : Controller
    {
        private readonly IProductService _productService;        

        public ProductController(IProductService productService)
        {
            _productService = productService;            
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productService.FindAllAsync();            

            if (!products.Any())
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByIdAsync(long id) 
        {
            var product = await _productService.FindByIdAsync(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}
