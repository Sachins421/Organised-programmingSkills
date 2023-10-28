using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ManufacturerSetup
{
    public class MfrSetup : DocumentSetup
    {
        [BsonElement(nameof(BaseData))]
        public BaseData BaseData { get; set; }

        [BsonElement(nameof(ServicePrices))]
        public ServicePrice[] ServicePrices { get; set; }

        [BsonElement(nameof(DecisionMapping))]
        public DecisionMapping DecisionMapping { get; set; }

        [BsonElement(nameof(ManGlassPackageMapping))]
        public ManGlassPackageMapping[] manGlassPackageMappings { get; set; }

        [BsonElement(nameof(ManGlassCodeMapping))]
        public ManGlassCodeMapping[] manGlassCodeMappings { get; set; }

        [BsonElement(nameof(AutoselectFilterChecks))]
        public AutoselectFilterChecks AutoselectFilterChecks { get; set; }

        [BsonElement(nameof(MessageID))]
        public string MessageID { get; set; }

        [BsonElement(nameof(TimeStamp))]
        public DateTime TimeStamp { get; set; }

    }
}
    