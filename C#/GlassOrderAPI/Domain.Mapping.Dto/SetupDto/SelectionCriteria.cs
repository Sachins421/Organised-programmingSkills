using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class SelectionCriteria
    {
        public bool LensOnStock { get; set; }
        public bool ExplicitCheck    { get; set; }
        public bool LineOptionValidation { get; set; }
        public bool OrderVolume { get; set; }
       
    }
}
