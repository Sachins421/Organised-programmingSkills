using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using ThirdParty.Json.LitJson;

namespace OnlinePizzaAPI.Models
{
    public class PizzaModel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string _id { get; set; }

        [BsonId]
        [BsonElement("Key")]
        [JsonPropertyName("Key")]
        public int Key { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [BsonElement("IsGlutenFree")]
        public bool IsGlutenFree { get; set; }

        [BsonElement("price")]
        public double price { get; set; }
    }
}
