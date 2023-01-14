using Catalog.API.AppSettingModels;
using Catalog.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {

        public CatalogContext(IOptions<MongoDbConfiguration> mongoDbOptions)
        {
            var mongoDbConf = mongoDbOptions.Value;
            var client = new MongoClient(mongoDbConf.ConnectionString);
            var database = client.GetDatabase(mongoDbConf.DatabaseName);

            Products = database.GetCollection<Product>(mongoDbConf.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
