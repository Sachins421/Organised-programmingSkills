using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ManufacturerSetup
{
    public class ManGlassPackageMapping
    {
        [BsonElement("Type")]
        public GlassPackageType Type { get; set; }

        [BsonElement("SF6LensNameFilter")]
        public string SF6LensNameFilter { get; set; }

        [BsonElement("GlassCatalogueName")]
        public string GlassCatalogueName { get; set; }

    }
}
