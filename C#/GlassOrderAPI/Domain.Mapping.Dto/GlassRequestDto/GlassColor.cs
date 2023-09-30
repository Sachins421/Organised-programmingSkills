using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.GlassRequestDto
{
    public class GlassColor
    {
        public string Color { get; set; }

        public string Manufacturer { get; set; }
        public int TingePercentage { get; set; }
        public int GradientPercentage { get; set; }
        public List<GlassColorPattern>? GlassColorPattern { get; set; }
    }
}
