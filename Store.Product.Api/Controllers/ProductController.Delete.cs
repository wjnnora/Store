using Microsoft.AspNetCore.Mvc;

namespace Store.Product.Api.Controllers
{
    public partial class ProductController
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] long id)
        {
            var product = await _productService.FindByIdAsync(id);

            if (product is null)
                return BadRequest("Product not found.");

            var result = await _productService.DeleteAsync(id);

            return Ok(result);
        }
    }
}
