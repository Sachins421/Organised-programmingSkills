using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ManufacturerSetup
{
    public class DecisionMapping
    {
        [BsonElement("MaxNoOfItemsPerOrder")]
        public int MaxNoOfItemsPerOrder { get; set; }

        [BsonElement("AllowedLensType")]
        public AllowedLensTypeOption AllowedLensType { get; set; }

        [BsonElement("OrderLimitTimePeriod")]
        public int OrderLimitTimePeriod { get; set; }

        [BsonElement("OrderLimitAPIThreshold")]
        public int OrderLimitAPIThreshold { get; set; }

        [BsonElement("FrameAvailabilityAPIThreshold")]
        public decimal FrameAvailabilityAPIThreshold { get; set; }

        [BsonElement("MaxOrderLimit")]
        public int MaxOrderLimit { get; set; }

        [BsonElement("AllowedSalesChannels")]
        public string AllowedSalesChannels { get; set; }

        [BsonElement("AllowedCountries")]
        public string AllowedCountries { get; set; }

        [BsonElement("AllowedShippingAgents")]
        public string AllowedShippingAgents { get; set; }

        [BsonElement("AllowSpecialInvReference")]
        public bool AllowSpecialInvReference { get; set; }

        [BsonElement("CheckLensStock")]
        public bool CheckLensStock { get; set; }

        [BsonElement("AllowLotusAutoUpgrade")]
        public bool AllowLotusAutoUpgrade { get; set; }

        [BsonElement("AllowFOVAutoUpgrade")]
        public bool AllowFOVAutoUpgrade { get; set; }

    }
}
