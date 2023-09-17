using MongoDB.Bson.Serialization.Attributes;

namespace Data.Data
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
