using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class GlassThicknessMinMax
    {
        [BsonElement("GlassPackageType")]
        public GlassPackageType glassPackageType { get; set; }
        [BsonElement("GlassThickness")]
        public decimal GlassThickness { get; set; }
        [BsonElement("MinValue")]
        public decimal MinValue { get; set; }
        [BsonElement("MaxValue")]
        public decimal MaxValue { get; set; }
        [BsonElement("Aspheric")]
        public Aspheric Aspheric { get; set; }

    }
}
