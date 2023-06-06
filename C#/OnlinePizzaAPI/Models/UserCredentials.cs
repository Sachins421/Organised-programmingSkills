using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlinePizzaAPI.Models
{
    public class UserCredentials
    {
        public ObjectId _id { get; set; }
        [BsonElement("userName")]
        public string? UserName { get; set;}
        
        public string? Password { get; set;}
    }
}
