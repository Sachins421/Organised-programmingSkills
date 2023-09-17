using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto
{
     #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public class SBMessages
    {
        public string topic { get; set; }

        public string eventType { get; set; }

        public string subject { get; set; }

        public string id { get; set; }

        public string eventTime { get; set; }

        public string dataVersion { get; set; }

        public string? LockToken { get; set; }

        public int DeliveryCount { get; set; }

        public bool IsDuplicate { get; set; } = false;
    }
}
