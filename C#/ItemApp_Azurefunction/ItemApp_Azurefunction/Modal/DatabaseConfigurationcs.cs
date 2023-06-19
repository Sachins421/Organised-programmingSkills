using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace ItemApp_Azurefunction.Modal
{
    public static class DatabaseConfigurationcs
    {
        public static IServiceCollection ConfigureMongoDB(this IServiceCollection services, string connectionString, string database)
        {
            services.AddSingleton<IMongoClient>(v => 
            { 
                return new MongoClient(connectionString); 
            });

            services.AddSingleton<IMongoDatabase>(v => v.GetRequiredService<IMongoClient>().GetDatabase(database));

            services.AddScoped<IItemRepository,ItemHandler>(); // in order first is interface then class 

            return services;
        }
    }
}
