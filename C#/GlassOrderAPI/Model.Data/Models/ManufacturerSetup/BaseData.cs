using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ManufacturerSetup
{
    public class BaseData
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("GlassCatalogueName")]
        public string GlassCatalogueName { get; set; }

        [BsonElement("VendorNo")]
        public string VendorNo { get; set; }

        [BsonElement("GlassDb")]
        public bool GlassDb { get; set; }

        [BsonElement("GlassRequestCleanValue")]
        public int GlassRequestCleanValue { get; set; }

        [BsonElement("GlassRequestCleanMultifokalInnenProgressive")]
        public int GlassRequestCleanMultifokalInnenProgressive { get; set; }

        [BsonElement("ManufactureMethod")]
        public ManufactureMethod ManufactureMethod { get; set; }

        [BsonElement("OutSourcedProduction")]
        public bool OutSourcedProduction { get; set; }

    }
}
