using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ManufacturerSetup
{
    public class ManGlassCodeMapping
    {
        [BsonElement(nameof(GlassCode))]
        public string GlassCode { get; set; }

        [BsonElement(nameof(GlassOptionCode))]
        public string GlassOptionCode { get; set; }

        [BsonElement(nameof(Photo))]
        public bool Photo { get; set; }
    }
}
