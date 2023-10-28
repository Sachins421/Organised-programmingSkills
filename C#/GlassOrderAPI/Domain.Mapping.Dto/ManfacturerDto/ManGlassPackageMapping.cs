using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public class ManGlassPackageMapping
    {
        public GlassPackageType Type { get; set; }

        public string SF6LensNameFilter { get; set; }
        public string GlassCatalogueName { get; set; }
    }
}
