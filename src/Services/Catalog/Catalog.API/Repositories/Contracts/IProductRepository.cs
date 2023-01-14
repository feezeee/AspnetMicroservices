using Catalog.API.Entities;

namespace Catalog.API.Repositories.Contracts
{
    public interface IProductRepository
    {
        public Task CreateAsync(Product product);
        public Task<bool> UpdateAsync(Product product);
        public Task<bool> DeleteAsync(string id);
    }
}
