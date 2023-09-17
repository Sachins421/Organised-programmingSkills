using Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Data
{
    public class PackageValues
    {
        [BsonElement(nameof(GlassType))]
        public GlassType GlassType { get; set; }
        [BsonElement(nameof(InnerProgression))]
        public bool InnerProgression { get; set; }
        [BsonElement(nameof(GlassPackageType))]

        public GlassPackageType GlassPackageType { get; set; }
        [BsonElement(nameof(TingePercentage))]
        public int? TingePercentage { get; set; }
        [BsonElement(nameof(GradientPercentage))]
        public int? GradientPercentage { get; set; }
        [BsonElement(nameof(TingeColor))]
        public string TingeColor { get; set; }
        [BsonElement(nameof(TingeType))]
        public TingeType TingeType { get; set; }
        [BsonElement(nameof(GlasThicknessForPrice))]
        public GlassPackageType GlasThicknessForPrice { get; set; }
        [BsonElement(nameof(LotusEffect))]
        public bool LotusEffect { get; set; }
        [BsonElement(nameof(Polished))]
        public bool Polished { get; set; }
        [BsonElement(nameof(DigitalRelax))]
        public bool DigitalRelax { get; set; }
        [BsonElement(nameof(ChannelLengh))]
        public ChannelLenghtType ChannelLengh { get; set; }
        [BsonElement(nameof(SunGlassTypePhoto))]
        public bool SunGlassTypePhoto { get; set; }
        [BsonElement(nameof(PolarizedGlass))]
        public bool PolarizedGlass { get; set; }
        [BsonElement(nameof(GlazingtoSample))]
        public bool GlazingtoSample { get; set; }
        [BsonElement(nameof(Mirrored))]
        public bool Mirrored { get; set; }
        [BsonElement(nameof(FieldofVision))]
        public string FieldofVision { get; set; }
        [BsonElement(nameof(Filter))]
        public bool? Filter { get; set; }
    }
}
