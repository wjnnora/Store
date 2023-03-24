using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Product.Api.Entity.Context;
using Store.Product.Api.Model;
using Store.Product.Api.Repository.Contract;

namespace Store.Product.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO model)
        {
            var product = _mapper.Map<Entity.Product>(model);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try 
            {
                var productDTO = await FindByIdAsync(id);

                var product = _mapper.Map<Entity.Product>(productDTO);

                if (product is null)
                    throw new Exception("Product not found.");

                _context.Products.Remove(product);
                return await _context.SaveChangesAsync() > 0;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> FindAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindByIdAsync(long id)
        {
            var product = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO model)
        {
            var product = _mapper.Map<Entity.Product>(model);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product) ;
        }
    }
}
