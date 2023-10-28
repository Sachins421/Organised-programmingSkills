using Model.Data.Models.ManufacturerSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Wrapper
{
    public class ManufacturerSetupRequestWrapper : MessageWrapper
    {
        public List<MfrSetup> Manufacturer { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
