using MongoDB.Driver;

namespace Model.Data.Repositries
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        IMongoClient GetClient();
        IMongoCollection<TDocument> GetCollection();
        IMongoDatabase GetDatabase();
    }
}