using Domain.Mapping.Dto;
using Domain.Mapping.GlassRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utilities.Response
{
    public class EventData
    {
        public SourceInformation sourceInformation { get; set; }
        public int glassEntryno { get; set; }
        public string messageId { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
