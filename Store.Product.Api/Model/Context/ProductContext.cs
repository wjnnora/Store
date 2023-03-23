using Microsoft.EntityFrameworkCore;

namespace Store.Product.Api.Model.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext() { }

        public ProductContext(DbContextOptions<ProductContext> options) : base (options) { }

        public DbSet<Product> Products { get; set; }
    }
}
