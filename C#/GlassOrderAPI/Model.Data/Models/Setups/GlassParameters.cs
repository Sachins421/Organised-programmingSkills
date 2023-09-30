using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class GlassParameters
    {
        [BsonElement("Disable")]
        public bool Disable { get; set; }
        [BsonElement("Combinations")]
        public List<Combinations> Combinations { get; set; }
    }
}
