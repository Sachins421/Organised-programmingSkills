using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGridApp
{
    public class MyEventData
    {
        [JsonProperty("message")]
        public string Message { get; set; } // Convert message to stronly typed object the matches the structure of event data
    }
}
