using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class SetupData
    {
        public SourceInformation? SourceInformation { get; set; }

        public BaseData BaseData { get; set; }

        public List<GlassThicknessMinMax> GlassThicknessMinMax { get; set; }

        public List<EventTypeMapping> EventTypeMappings { get; set; }

        public GlassParameters GlassSelectionsParameters { get; set; }

        public string MessageID { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Source { get; set; }
    }
}
