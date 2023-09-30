using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utilities.Response
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class EventResponse
    {

        public string Topic { get; set; }
        public string eventType { get; set; }
        public string subject { get; set; }
        public string id { get; set; }
        public string version { get; set; }
        public dynamic data { get; set; }
        public bool isCompressed { get; set; }
        public DateTime? lastUpdatedSetupTimeStamp { get; set; }
    }
}
