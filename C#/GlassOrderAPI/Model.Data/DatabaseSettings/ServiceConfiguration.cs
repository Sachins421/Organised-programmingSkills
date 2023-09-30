using Model.Data.DatabaseSettings;
using Model.Data.Repositries;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Servers;
using Model.Data.Repositries.Setup;

namespace Data.DatabaseSetting
{
    public static class ServiceConfiguration
    {   
        public static IServiceCollection ConfigurMongoDB(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(s =>
            {
                var consettings = s.GetRequiredService<DBSettings>();
                var mongourl = new MongoUrl(consettings.ConnectionString);
                MongoClientSettings mongoClientSettings = MongoClientSettings.FromUrl(mongourl);
                return new MongoClient(mongoClientSettings);
            });

            //services.AddSingleton<IMongoDatabase>(s => s.GetRequiredService<MongoClient>().GetDatabase());
            services.AddSingleton<IMongoDatabase>(svc =>
               svc.GetRequiredService<IMongoClient>()
                   .GetDatabase(svc.GetRequiredService<DBSettings>().DatabaseName));

            services.AddScoped(typeof(IMongoRepository<>),typeof(MongoRepository<>));
            services.AddScoped<IProductionLineRepository, ProductionLineRepository>();
            services.AddScoped<ISetupRepository, SetupRepository>();
 
            return services;
        }
    }
}
