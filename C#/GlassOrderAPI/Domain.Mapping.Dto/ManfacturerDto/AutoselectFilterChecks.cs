using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public class AutoselectFilterChecks
    {
        public bool Enabled { get; set; }
        public string[] FrameTypeFilter { get; set; }

        public bool? Multifocal { get; set; }

        public GlassThicknessMinMax SphereLeftFilter { get; set; }

        public GlassThicknessMinMax SphereRightFilter { get; set; }

        public GlassThicknessMinMax CylinderLeftFilter { get; set; }

        public GlassThicknessMinMax CylinderRightFilter { get; set; }

        public bool CommentsforWorkshop { get; set; }

        public ColourTingeFilteringOption ColorTinge { get; set; }

        public bool? DigitalRelax { get; set; }

        public string[] TingeTypeFilter { get; set; }
        public decimal IgnoreLotusGlassThknsFltr { get; set; }
    }
}
