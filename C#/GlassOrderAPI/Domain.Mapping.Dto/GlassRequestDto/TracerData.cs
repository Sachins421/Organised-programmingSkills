using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.GlassRequestDto
{
    public class TracerData
    {
        public int EntryNo { get; set; }
        public decimal DistanceBetweenLenses { get; set; }
        public string GlassTracingData { get; set; }
    }
}
