using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ManufacturerSetup
{
    public class GlassThicknessMinMax
    {
        [BsonElement("GlassPackageType")]
        public GlassPackageType glassPackageType { get; set; }
        [BsonElement("GlassThickness")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal GlassThickness { get; set; }
        [BsonElement("MinValue")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal MinValue { get; set; }
        [BsonElement("MaxValue")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal MaxValue { get; set; }
        [BsonElement("Aspheric")]
        public Aspheric Aspheric { get; set; }

    }
}
