using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ManufacturerSetup
{
    public class ManufacturerSetupData
    {
        [BsonElement("manufacturerSetup")]
        public MfrSetup[] MfrSetup { get; set; }

        [BsonElement("messageID")]
        public string MessageID { get; set; }

        [BsonElement("timeStamp")]
        public DateTime TimeStamp { get; set; }

    }
}
