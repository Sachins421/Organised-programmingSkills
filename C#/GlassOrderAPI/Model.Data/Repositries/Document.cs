using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Model.Data.Repositries
{
    public abstract class Document : IDocument
    {
        [BsonId, BsonElement("_id")]
        [JsonProperty(PropertyName = "_id")]
        public Id Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement(nameof(CreatedAt))]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement(nameof(UpdatedAt))]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}