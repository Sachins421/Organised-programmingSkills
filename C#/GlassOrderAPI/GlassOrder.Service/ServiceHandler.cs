using Data.DatabaseSettings;
using Domain.Mapping.Dto;
using MongoDB.Driver;

namespace GlassOrder.Service
{
    public class ServiceHandler
    {
        private readonly IMongoCollection<GlassRequest> mongoCollection;
        private readonly IMongoDatabase database;

        public ServiceHandler(DatabaseSettings settings,IMongoClient mongoClient)
        {
            database = mongoClient.GetDatabase(settings.DatabaseName);
            mongoCollection = database.GetCollection<GlassRequest>(settings.collection);
        }

        public void HandleGlassRequest(GlassRequest glassRequest)
        {
            mongoCollection.InsertOne(glassRequest);
            
        }
    }
}
