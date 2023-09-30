using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class Restrictions
    {
        [BsonElement("AllowedSalesChannel")]
        public bool AllowedSalesChannel { get; set; }
        [BsonElement("AllowedCountryCode")]
        public bool AllowedCountryCode { get; set; }
        [BsonElement("AllowedShippingAgent")]
        public bool AllowedShippingAgent { get; set; }

        [BsonElement("AllowSpecialInvReference")]
        public bool AllowSpecialInvReference { get; set; }
        [BsonElement("NoOfItemPerOrder")]
        public bool NoOfItemPerOrder { get; set; }
        [BsonElement("FrameAvailability")]
        public bool FrameAvailability { get; set; }
        [BsonElement("AllowedLensTypeOption")]
        public bool AllowedLensTypeOption { get; set; }

    }
}
