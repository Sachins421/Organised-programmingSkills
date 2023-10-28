using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Data.Models.ManufacturerSetup
{
    public class AutoselectFilterChecks
    {
        [BsonElement("Enabled")]
        public bool Enabled { get; set; }

        [BsonElement("FrameTypeFilter")]
        public string[] FrameTypeFilter { get; set; }

        [BsonElement("Multifocal")]
        public bool? Multifocal { get; set; }

        [BsonElement("SphereLeftFilter")]
        public GlassThicknessMinMax SphereLeftFilter { get; set; }

        [BsonElement("SphereRightFilter")]
        public GlassThicknessMinMax SphereRightFilter { get; set; }

        [BsonElement("CylinderLeftFilter")]
        public GlassThicknessMinMax CylinderLeftFilter { get; set; }

        [BsonElement("CylinderRightFilter")]
        public GlassThicknessMinMax CylinderRightFilter { get; set; }

        [BsonElement("CommentsforWorkshop")]
        public bool CommentsforWorkshop { get; set; }

        [BsonElement("ColorTinge")]
        public ColourTingeFilteringOption ColorTinge { get; set; }

        [BsonElement("DigitalRelax")]
        public bool? DigitalRelax { get; set; }

        [BsonElement("TingeTypeFilter")]
        public string[] TingeTypeFilter { get; set; }

        [BsonElement("IgnoreLotusGlassThknsFltr")]
        public decimal IgnoreLotusGlassThknsFltr { get; set; }

    }
}
