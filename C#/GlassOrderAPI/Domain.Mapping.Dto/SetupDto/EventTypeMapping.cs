using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class EventTypeMapping
    {
        public int FunctionName { get; set; }
        public string EventType { get; set; }
        public List<NextSteps> NextSteps { get; set; }
        public int MaxRetryAttempts { get; set; }
        public List<ErrorMapping> errorMappings { get; set; }   
    }
}
