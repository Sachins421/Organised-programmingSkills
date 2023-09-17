using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Wrapper
{
#pragma warning disable CS8618
    public class MessageResponseWrapper
    {
        public string LockToken { get; set; }

        public int DeliveryCount { get; set; }

        public string MessageId { get; set; }

        public bool Success { get; set; } = false;

        public bool DeadLetter { get; set; } = false;

        public string Reason { get; set; }

        public bool IsDuplicate { get; set; } = false;

        public bool IsEarlierTimestamp { get; set; } = false;

        public bool IsEvent { get; set; } = false;
        public string EventType { get; set; }
        public string Topic { get; set; }
        public int GlassRequestEntryNo { get; set; }
        public string Subject { get; set; }
        public DateTime? LastUpdatedManufacturerTimeStamp { get; set; }
        public DateTime? LastUpdatedSetupTimeStamp { get; set; }
    }
}
