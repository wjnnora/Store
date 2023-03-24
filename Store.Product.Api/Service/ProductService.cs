using AutoMapper;
using Store.Product.Api.Model;
using Store.Product.Api.Repository.Contract;
using Store.Product.Api.Service.Contract;

namespace Store.Product.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productService)
        {
            _mapper = mapper;
            _productRepository = productService;
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO model)
        {
            var product = _mapper.Map<Entity.Product>(model);

            product = await _productRepository.CreateAsync(product);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var product = await _productRepository.FindByIdAsync(id);

            return await _productRepository.DeleteAsync(product);
        }

        public async Task<IEnumerable<ProductDTO>> FindAllAsync()
        {
            var products = await _productRepository.FindAllAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);            
        }

        public async Task<ProductDTO> FindByIdAsync(long id)
        {
            var product = await _productRepository.FindByIdAsync(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO model)
        {
            var product = _mapper.Map<Entity.Product>(model);

            product = await _productRepository.UpdateAsync(product);

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
