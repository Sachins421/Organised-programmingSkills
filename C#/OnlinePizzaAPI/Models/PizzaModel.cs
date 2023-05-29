using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlinePizzaAPI.Models
{
    public class PizzaModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public int Id { get; set; }
        [BsonElement("Name")]
        public string? Description { get; set; }
        public bool IsGlutenFree { get; set; }
        public double price { get; set; }
    }
}
