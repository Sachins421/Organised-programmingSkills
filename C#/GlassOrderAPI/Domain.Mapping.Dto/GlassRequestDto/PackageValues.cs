using Data.Enums;

namespace Domain.Mapping.GlassRequestDto
{
    public class PackageValues
    {
        public GlassType GlassType { get; set; }
        public bool InnerProgression { get; set; }

        public GlassPackageType GlassPackageType { get; set; }

        public int? TingePercentage { get; set; }
        public int? GradientPercentage { get; set; }
        public string TingeColor { get; set; }
        public TingeType TingeType { get; set; }
        public GlassPackageType GlasThicknessForPrice { get; set; }
        public bool LotusEffect { get; set; }
        public bool Polished { get; set; }
        public bool DigitalRelax { get; set; }
        public ChannelLenghtType ChannelLengh { get; set; }
        public bool SunGlassTypePhoto { get; set; } 
        public bool PolarizedGlass { get; set; }
        public bool GlazingtoSample { get; set; }
        public bool Mirrored { get; set; }
        public string FieldofVision { get; set; }
        public bool? Filter { get; set; }


    }
}
