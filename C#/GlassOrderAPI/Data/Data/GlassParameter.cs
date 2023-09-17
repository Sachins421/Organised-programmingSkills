using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class GlassParameter
    {
        [BsonElement(nameof(Name))]
        public string Name { get; set; }
        [BsonElement(nameof(Type))]
        public int Type { get; set; }
        [BsonElement(nameof(BasicCurve))]
        public decimal BasicCurve { get; set; }
        [BsonElement(nameof(Diameter))]
        public decimal Diameter { get; set; }
        [BsonElement(nameof(PDL))]
        public decimal PDL { get; set; }
        [BsonElement(nameof(SphereL))]
        public decimal SphereL { get; set; }
        [BsonElement(nameof(CylinderL))]
        public decimal CylinderL { get; set; }

        [BsonElement(nameof(AxisL))]
        public decimal AxisL { get; set; }
        [BsonElement(nameof(AddL))]
        public decimal AddL { get; set; }
        [BsonElement(nameof(GrindL))]
        public decimal GrindL { get; set; }
        [BsonElement(nameof(PDL))]
        public decimal PDR { get; set; }
        [BsonElement(nameof(SphereR))]
        public decimal SphereR { get; set; }
        [BsonElement(nameof(CylinderR))]
        public decimal CylinderR { get; set; }
        [BsonElement(nameof(AxisR))]
        public decimal AxisR { get; set; }
        [BsonElement(nameof(AddR))]
        public decimal AddR { get; set; }
        [BsonElement(nameof(GrindR))]
        public decimal GrindR { get; set; }
        [BsonElement(nameof(GlassThickness))]
        public decimal GlassThickness { get; set; }
        [BsonElement(nameof(PolarizedGlass))]
        public bool PolarizedGlass { get; set; }
    }
}
