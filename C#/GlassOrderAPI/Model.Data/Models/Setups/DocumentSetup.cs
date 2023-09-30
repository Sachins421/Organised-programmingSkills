using Model.Data.Repositries;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class DocumentSetup : Document
    {
        [BsonId, BsonElement("_id")]
        public string _id { get; set; }

        [BsonElement("Company")]
        public string Company { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
