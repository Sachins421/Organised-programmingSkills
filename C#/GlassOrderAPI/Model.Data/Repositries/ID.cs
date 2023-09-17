using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Model.Data.Repositries
{
    public class Id
    {
        [BsonId, BsonElement("_id")]
        [JsonProperty(PropertyName = "_id")]
        public string id { get; set; }

        [BsonElement(nameof(SalesChannel))]
        public string SalesChannel { get; set; }

        [BsonElement(nameof(SalesCountryISO))]
        public string SalesCountryISO { get; set; }

        [BsonElement(nameof(LineNo))]
        public string LineNo { get; set; }
    }
}
