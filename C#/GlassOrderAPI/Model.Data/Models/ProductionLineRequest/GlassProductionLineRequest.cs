using Model.Data.Repositries;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Data.Models.ProductionLineRequest
{
    public class GlassProductionLineRequest : Document
    {
        [BsonElement(nameof(Execution))]
        public Execution Execution { get; set; }

        [BsonElement(nameof(ArchivedExecutions))]
        public List<Execution> ArchivedExecutions { get; set; }
    }
}
