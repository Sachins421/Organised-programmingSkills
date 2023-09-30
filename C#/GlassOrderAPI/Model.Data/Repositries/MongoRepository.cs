using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Model.Data.Repositries
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<TDocument> _collection;
        private readonly ILogger _logger;

        public MongoRepository(ILogger<MongoRepository<TDocument>> logger,IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        {
            _logger = logger;
            _database = mongoDatabase ?? throw new ArgumentNullException(nameof(mongoDatabase));
            _mongoClient = mongoClient ?? throw new ArgumentNullException(nameof(mongoClient));
            //_collection = _database.GetCollection<TDocument>(nameof(TDocument).Name);
            _collection = _database.GetCollection<TDocument>(typeof(TDocument).Name);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database; // return Database
        }

        public IMongoCollection<TDocument> GetCollection()
        {
            return _collection; // return collection name based on TDocument defined
        }

        public IMongoClient GetClient()
        {
            return _mongoClient; //return mongo client 
        }
    }
}