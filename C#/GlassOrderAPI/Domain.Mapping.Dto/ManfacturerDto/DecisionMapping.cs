using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public class DecisionMapping
    {
        public int MaxNoOfItemsPerOrder { get; set; }
        public AllowedLensTypeOption AllowedLensType { get; set; }

        public int OrderLimitTimePeriod { get; set; }

        public int OrderLimitAPIThreshold { get; set; }

        public decimal FrameAvailabilityAPIThreshold { get; set; }

        public int MaxOrderLimit { get; set; }

        public string AllowedSalesChannels { get; set; }

        public string AllowedCountries { get; set; }

        public string AllowedShippingAgents { get; set; }

        public bool AllowSpecialInvReference { get; set; }

        public bool CheckLensStock { get; set; }

        public bool AllowLotusAutoUpgrade { get; set; }

        public bool AllowFOVAutoUpgrade { get; set; }
    }
}
