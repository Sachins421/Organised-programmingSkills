using MongoDB.Bson.Serialization.Attributes;

namespace Model.Data.ProductionLineRequest
{
    public class Execution
    {
        [BsonElement("GlassRequest")]
        public GlassRequests.GlassRequest GlassRequest { get; set; }

        [BsonElement(nameof(GlassRequestEntryNo))]
        public int GlassRequestEntryNo { get; set; }

        /// <summary>
        /// Message TimeStamp
        /// </summary>
        [BsonElement(nameof(TimeStamp))]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Message Source
        /// </summary>
        [BsonElement(nameof(Source))]
        public string Source { get; set; }
    }
}
