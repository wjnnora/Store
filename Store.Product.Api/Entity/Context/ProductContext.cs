using Microsoft.EntityFrameworkCore;

namespace Store.Product.Api.Entity.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext() { }

        public ProductContext(DbContextOptions<ProductContext> options) : base (options) { }

        public DbSet<Product> Products { get; set; }
    }
}
