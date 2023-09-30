using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class EventTypeMapping
    {
        [BsonElement("FunctionName")]
        public int FunctionName { get; set; }
        [BsonElement("EventType")]
        public string EventType { get; set; }
        [BsonElement("NextSteps")]
        public List<NextSteps> NextSteps { get; set; }
        [BsonElement("MaxRetryAttempts")]
        public int MaxRetryAttempts { get; set; }
        [BsonElement("ErrorMapping")]
        public List<ErrorMapping> errorMappings { get; set; }
    }
}
