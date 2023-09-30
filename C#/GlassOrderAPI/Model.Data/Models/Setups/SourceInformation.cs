using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class SourceInformation
    {
        [BsonElement("Code")]
        public string Code { get; set; }
        [BsonElement("Company")]
        public string Company { get; set; }
    }
}
