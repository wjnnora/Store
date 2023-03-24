namespace Store.Product.Api.Repository.Contract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entity.Product>> FindAllAsync();
        Task<Entity.Product> FindByIdAsync(long id);
        Task<Entity.Product> CreateAsync(Entity.Product product);
        Task<Entity.Product> UpdateAsync(Entity.Product product);
        Task<bool> DeleteAsync(Entity.Product product);
    }
}
