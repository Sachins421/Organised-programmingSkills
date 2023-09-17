using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Repositries
{
    public interface IDocument
    {
        [BsonId, BsonElement("_id")]
        public Id Id {  get; set; }
    }
}
