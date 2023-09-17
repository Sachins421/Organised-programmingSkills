using MongoDB.Bson.Serialization.Attributes;

namespace Data.Data
{
    public class OrderLine
    {
        [BsonElement(nameof(type))]
        public string type { get; set; }
        [BsonElement(nameof(No))]
        public string No { get; set; }
        [BsonElement(nameof(LineNo))]
        public int LineNo { get; set; }
        [BsonElement(nameof(Quantity))]
        public decimal Quantity { get; set; }
        [BsonElement(nameof(ItemCategory))]
        public string ItemCategory { get; set; }
    }
}
