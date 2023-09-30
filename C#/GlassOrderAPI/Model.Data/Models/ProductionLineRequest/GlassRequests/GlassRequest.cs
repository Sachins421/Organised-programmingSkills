using MongoDB.Bson.Serialization.Attributes;

namespace Model.Data.Models.ProductionLineRequest.GlassRequests
{
    public class GlassRequest
    {
        [BsonElement(nameof(BaseData))]
        public BaseData BaseData { get; set; }

        [BsonElement(nameof(TracerData))]
        public TracerData TracerData { get; set; }

        [BsonElement(nameof(GlassColors))]
        public List<GlassColor> GlassColors { get; set; }

        [BsonElement(nameof(GlassParameter))]
        public GlassParameter GlassParameter { get; set; }

        [BsonElement(nameof(OrderLines))]
        public List<OrderLine> OrderLines { get; set; }

        [BsonElement(nameof(Availabilities))]
        public List<Availability> Availabilities { get; set; }

        [BsonElement(nameof(Item))]
        public Item Item { get; set; }

        [BsonElement(nameof(Counter))]
        public int Counter { get; set; }

        [BsonElement(nameof(Source))]
        public string Source { get; set; }

        [BsonElement(nameof(MessageID))]
        public string MessageID { get; set; }

        [BsonElement(nameof(TimeStamp))]
        public DateTime TimeStamp { get; set; }

    }
}
