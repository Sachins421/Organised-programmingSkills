using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Domain.Mapping.Dto
{
    public class GlassRequest
    {
        public SourceInformation SourceInformation { get; set; }

        public BaseData BaseData { get; set; }

        public TracerData TracerData { get; set; }

        public List<GlassColor>? GlassColor { get; set; }

        public GlassParameter GlasParameter { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public List<Availability> Availabilities { get; set; }
        public Item Item { get; set; }

        public int Counter { get; set; }

        public string Source { get; set; }

        public string MessageID { get; set; }

        public DateTime TimeStamp { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
