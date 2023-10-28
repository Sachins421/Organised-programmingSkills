using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public class ManGlassCodeMapping
    {
        public string GlassCode { get; set; }
        public string GlassOptionCode { get; set; }
        public bool Photo { get; set; }
    }
}
