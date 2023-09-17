using Model.Data.DatabaseSettings;
using Model.Data.Repositries;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using Service.Repositries;
using MongoDB.Driver.Core.Servers;

namespace Data.DatabaseSetting
{
    public static class ServiceConfiguration
    {   
        public static IServiceCollection ConfigurMongoDB(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(s =>
            {
                var consettings = s.GetRequiredService<DBSettings>();
                var clientSettings = new MongoClientSettings
                {
                    Server =  new MongoServerAddress(consettings.ConnectionString)
            };
                return new MongoClient(clientSettings);
            });

            //services.AddSingleton<IMongoDatabase>(s => s.GetRequiredService<MongoClient>().GetDatabase());
            services.AddSingleton<IMongoDatabase>(svc =>
               svc.GetRequiredService<IMongoClient>()
                   .GetDatabase(svc.GetRequiredService<DBSettings>().DatabaseName));

            services.AddScoped(typeof(IMongoRepository<>),typeof(MongoRepository<>));
            services.AddScoped<IProductionLineRepository, ProductionLineRepository>();
           

            return services;
        }
    }
}
