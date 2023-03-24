using Microsoft.AspNetCore.Mvc;
using Store.Product.Api.Model;

namespace Store.Product.Api.Controllers
{
    public partial class ProductController
    {
        [HttpPost]
        public async Task<IActionResult> PostProductAsync([FromBody] ProductDTO model)
        {
            var product = await _productService.CreateAsync(model);

            return Ok(product);
        }
    }
}
