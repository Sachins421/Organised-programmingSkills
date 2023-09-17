using MongoDB.Bson.Serialization.Attributes;

namespace Data.Data
{
    public class GlassColorPattern
    {
        [BsonElement(nameof(MirroredGlass))]
        public string MirroredGlass { get; set; }
    }
}
