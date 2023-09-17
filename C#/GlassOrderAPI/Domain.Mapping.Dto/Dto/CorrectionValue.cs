using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto
{
    public class CorrectionValue
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal BasicCurve { get; set; }
        public decimal Diameter { get; set; }
        public decimal PDL { get ; set; }
        public decimal SphereL { get; set; }
        public decimal CylinderL { get; set; }
        public decimal AxisL { get; set; }
        public decimal AddL { get; set; }
        public decimal GrindL { get; set; }
        public decimal PDR { get; set; }
        public decimal SphereR { get; set; }
        public decimal CylinderR { get; set; }
        public decimal AxisR { get; set; }
        public decimal AddR { get; set; }
        public decimal GrindR { get; set; }
        public decimal GlassThickness { get; set; }
        public bool PolarizedGlass { get; set; }
    }
}
