using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Data.Models.ProductionLineRequest.GlassRequests
{
    public class GlassColor
    {
        [BsonElement(nameof(Color))]
        public string Color { get; set; }

        [BsonElement(nameof(Manufacturer))]
        public string Manufacturer { get; set; }
        [BsonElement(nameof(TingePercentage))]
        public int TingePercentage { get; set; }
        [BsonElement(nameof(GradientPercentage))]
        public int GradientPercentage { get; set; }
        [BsonElement(nameof(GlassColorPattern))]
        public List<GlassColorPattern> GlassColorPattern { get; set; }
    }
}
