using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto
{
    public class Availability
    {
        public string Manufacturer { get; set; }
        public string Location { get; set; }
        public decimal Available { get; set; }

    }
}
