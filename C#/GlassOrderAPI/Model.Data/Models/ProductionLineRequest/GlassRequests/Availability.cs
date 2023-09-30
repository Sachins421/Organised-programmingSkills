using MongoDB.Bson.Serialization.Attributes;

namespace Model.Data.Models.ProductionLineRequest.GlassRequests
{
    public class Availability
    {
        [BsonElement(nameof(Manufacturer))]
        public string Manufacturer { get; set; }

        [BsonElement(nameof(Location))]
        public string Location { get; set; }

        [BsonElement(nameof(Available))]
        public decimal Available { get; set; }

    }
}
