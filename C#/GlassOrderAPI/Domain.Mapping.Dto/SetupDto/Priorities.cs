using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class Priorities
    {
        public int Priority { get; set; }
        public List<Manufacturers> Manufacturers { get; set; }
        
    }
}
