using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ManufacturerSetup
{
    public class ServicePrice
    {
        [BsonElement("manufactureMethod")]
        public ManufactureMethod ManufactureMethod { get; set; }

        [BsonElement("physicalFrameType")]
        public string PhysicalFrameType { get; set; }

        [BsonElement("serviceType")]
        public ServicePriceType ServiceType { get; set; }

        [BsonElement("directUnitCost")]
        public float DirectUnitCost { get; set; }

    }
}
