using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class ErrorMapping
    {
        public int ErrorType { get; set; }
        public string subject { get; set; }
        public string EventType { get; set; }
        public string Topic { get; set; }
        public int ActionType { get; set; }
    }
}
