using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DatabaseSettings
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigurMongoDB(this IServiceCollection services, string ConnectionString, string Database)
        {
            services.AddSingleton<MongoClient>(s =>
            {
                return new MongoClient(ConnectionString);
            });

            services.AddSingleton<IMongoDatabase>(s => s.GetRequiredService<MongoClient>().GetDatabase(Database));

            return services;
        }
    }
}
