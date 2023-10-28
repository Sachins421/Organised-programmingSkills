using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public class BaseData
    {
        public string Name { get; set; }
        public string GlassCatalogueName { get; set; }
        public string VendorNo { get; set; }
        public bool GlassDb { get; set; }
        public int GlassRequestCleanValue { get; set; }
        public int GlassRequestCleanMultifokalInnenProgressive { get; set; }
        public ManufactureMethod ManufactureMethod { get; set; }
        public bool OutSourcedProduction { get; set; }
    }
}
