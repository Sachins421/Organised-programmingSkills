using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public class ServicePrices
    {
        public ManufactureMethod ManufactureMethod { get; set; }

        public string PhysicalFrameType { get; set; }

        public ServicePriceType ServiceType { get; set; }

        public float DirectUnitCost { get; set; }
    }
}
