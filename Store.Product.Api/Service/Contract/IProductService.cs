using Store.Product.Api.Model;

namespace Store.Product.Api.Service.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> FindAllAsync();
        Task<ProductDTO> FindByIdAsync(long id);
        Task<ProductDTO> CreateAsync(ProductDTO model);
        Task<ProductDTO> UpdateAsync(ProductDTO model);
        Task<bool> DeleteAsync(long model);
    }
}
