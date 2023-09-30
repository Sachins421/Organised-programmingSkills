using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class Priorities
    {
        [BsonElement("Priority")]
        public int Priority { get; set; }
        [BsonElement("Manufacturers")]
        public List<Manufacturers> Manufacturers { get; set; }

    }
}
