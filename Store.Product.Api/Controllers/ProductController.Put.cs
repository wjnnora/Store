using Microsoft.AspNetCore.Mvc;
using Store.Product.Api.Model;

namespace Store.Product.Api.Controllers
{
    public partial class ProductController
    {
        [HttpPut]
        public async Task<IActionResult> PutProductAsync([FromBody] ProductDTO model)
        {
            var product = await _productService.FindByIdAsync(model.Id);

            if (product is null)
                return BadRequest("Product not found.");

            var result = await _productService.UpdateAsync(model);

            return View(result);
        }
    }
}
