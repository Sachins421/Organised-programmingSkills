using ItemApp_Azurefunction;
using ItemApp_Azurefunction.Modal;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
[assembly: FunctionsStartup(typeof(ItemApp_Azurefunction.Startup))]

namespace ItemApp_Azurefunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureDatabse(builder);
        }

        private static void ConfigureDatabse(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("MongoConnectionString");
            string databaseName = Environment.GetEnvironmentVariable("MongoDatabase");
            builder.Services.ConfigureMongoDB(connectionString, databaseName);
        }
    }
}
