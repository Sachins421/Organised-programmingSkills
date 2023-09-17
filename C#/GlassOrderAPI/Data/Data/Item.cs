using Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class Item
    {
        [BsonElement(nameof(ItemNo))]
        public string ItemNo { get; set; }

        [BsonElement(nameof(Description))]
        public string Description { get; set; }

        [BsonElement(nameof(ItemCategory))]
        public string ItemCategory { get; set; }

        [BsonElement(nameof(PhysicalFrameType))]
        public string PhysicalFrameType { get; set; }

        [BsonElement(nameof(FrontMaterial))]
        public string FrontMaterial { get; set; }

        [BsonElement(nameof(ManufactureMethod))]
        public string ManufactureMethod { get; set; }

        [BsonElement(nameof(Glazable))]
        public string Glazable { get; set; }

        [BsonElement(nameof(EdgeThickness))]
        public decimal EdgeThickness { get; set; }

        [BsonElement(nameof(Aspheric))]
        public Aspheric Aspheric { get; set; }

        [BsonElement(nameof(FrontCurve))]
        public decimal FrontCurve { get; set; }

        [BsonElement(nameof(GlassWidth))]
        public decimal GlassWidth { get; set; }

        [BsonElement(nameof(BarWidth))]
        public decimal BarWidth { get; set; }
    }
}
