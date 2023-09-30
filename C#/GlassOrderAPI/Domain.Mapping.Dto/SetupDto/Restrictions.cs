using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class Restrictions
    {
        public bool AllowedSalesChannel { get; set; }
        public bool AllowedCountryCode { get; set; }
        public bool AllowedShippingAgent { get; set; }
        public bool AllowSpecialInvReference { get; set; }
        public bool NoOfItemPerOrder { get; set; }
        public bool FrameAvailability { get; set; }
        public bool AllowedLensTypeOption { get; set; }

    }
}
