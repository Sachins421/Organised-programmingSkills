using MongoDB.Bson.Serialization.Attributes;

namespace Model.Data.ProductionLineRequest.GlassRequests
{
    public class GlassColorPattern
    {
        [BsonElement(nameof(MirroredGlass))]
        public string MirroredGlass { get; set; }
    }
}
