using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class SelectionCriteria
    {
        [BsonElement("LensOnStock")]
        public bool LensOnStock { get; set; }
        [BsonElement("ExplicitCheck")]
        public bool ExplicitCheck { get; set; }
        [BsonElement("LineOptionValidation")]
        public bool LineOptionValidation { get; set; }
        [BsonElement("OrderVolume")]
        public bool OrderVolume { get; set; }

    }
}
