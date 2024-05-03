
using FoodieRider.Cosmos.CosmosServices;
using Microsoft.Azure.Cosmos;

namespace FoodieRider.API.Configuration
{
    public class CosmosServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<ICosmosItemService, CosmosItemService>();
            services.AddSingleton<ICosmosItemService>(options =>
            {
                string url = configuration.GetSection("CosmosConnection")
                .GetValue<string>("URL");
                string primaryKey = configuration.GetSection("CosmosConnection")
                .GetValue<string>("PrimaryKey");
                string dbName = configuration.GetSection("CosmosConnection")
                .GetValue<string>("DatabaseName");
                string containerName = configuration.GetSection("CosmosConnection")
                .GetValue<string>("ContainerName");

                var cosmosClient = new CosmosClient(
                    url,
                    primaryKey
                );

                return new CosmosItemService(cosmosClient, dbName, containerName);
            });
        }
    }
}
