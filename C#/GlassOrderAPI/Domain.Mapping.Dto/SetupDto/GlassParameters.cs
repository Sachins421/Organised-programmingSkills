using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class GlassParameters
    {
        public bool Disable { get; set; }
        public List<Combinations> Combinations { get; set; }
    }
}
