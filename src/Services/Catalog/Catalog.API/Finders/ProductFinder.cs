using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Finders.Contracts;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.API.Finders
{
    public class ProductFinder : IProductFinder
    {
        private readonly ICatalogContext _catalogContext;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ProductFinder(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var res = await _catalogContext.Products.Find(p => true).ToListAsync();
            return res;
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            var res = await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
            return res;
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            var res = await _catalogContext.Products.Find(filter).ToListAsync();
            return res;
        }

        public async Task<IEnumerable<Product>> GetByCategoryNameAsync(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            var res = await _catalogContext.Products.Find(filter).ToListAsync();
            return res;
        }
    }
}
