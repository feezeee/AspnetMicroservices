using Microsoft.AspNetCore.SignalR;

namespace Catalog.API.AppSettingModels
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
