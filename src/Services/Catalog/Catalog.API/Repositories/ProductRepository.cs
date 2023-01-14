using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Repositories.Contracts;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task CreateAsync(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);


            var res = await _catalogContext
                .Products
                .ReplaceOneAsync(filter: filter, replacement: product);

            return res.IsAcknowledged
                   && res.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            var res = await _catalogContext.Products.DeleteOneAsync(filter);
            return res.IsAcknowledged && res.DeletedCount > 0;
        }
    }
}
