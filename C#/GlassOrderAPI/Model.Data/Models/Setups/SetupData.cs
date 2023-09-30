using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class SetupData : DocumentSetup
    {
        [BsonElement("SourceInformation")]
        public SourceInformation SourceInformation { get; set; }

        [BsonElement("BaseData")]
        public BaseData BaseData { get; set; }

        [BsonElement("GlassThickness")]
        public List<GlassThicknessMinMax> GlassThicknessMinMax { get; set; }

        [BsonElement("EventTypeMapping")]
        public List<EventTypeMapping> EventTypeMappings { get; set; }

        [BsonElement("GlassSelectionParameters")]
        public GlassParameters GlassSelectionsParameters { get; set; }

        [BsonElement("MessageID")]
        public string MessageID { get; set; }

        [BsonElement("TimeStamp")]
        public DateTime TimeStamp { get; set; }

        [BsonElement("Source")]
        public string Source { get; set; }
    }
}
