using Microsoft.EntityFrameworkCore;
using Store.Product.Api.Entity.Context;
using Store.Product.Api.Repository.Contract;

namespace Store.Product.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;        

        public ProductRepository(ProductContext context)
        {
            _context = context;            
        }

        public async Task<Entity.Product> CreateAsync(Entity.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(Entity.Product product)
        {
            _context.Products.Remove(product);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Entity.Product>> FindAllAsync()
        {
            return await _context.Products.ToListAsync();            
        }

        public async Task<Entity.Product> FindByIdAsync(long id)
        {
            return await _context.Products.FindAsync(id);            
        }

        public async Task<Entity.Product> UpdateAsync(Entity.Product product)
        {
            _context.ChangeTracker.Clear();
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
