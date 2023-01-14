using Catalog.API.Entities;

namespace Catalog.API.Finders.Contracts
{
    public interface IProductFinder
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product?> GetByIdAsync(string id);
        public Task<IEnumerable<Product>> GetByNameAsync(string name);
        public Task<IEnumerable<Product>> GetByCategoryNameAsync(string categoryName);
    }
}
