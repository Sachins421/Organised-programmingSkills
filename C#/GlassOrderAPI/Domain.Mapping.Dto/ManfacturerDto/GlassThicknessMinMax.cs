using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public class GlassThicknessMinMax
    {
        public GlassPackageType glassPackageType { get; set; }
        public decimal GlassThickness { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public Aspheric Aspheric { get; set; }
    }
}
