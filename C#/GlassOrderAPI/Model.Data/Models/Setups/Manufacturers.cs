using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class Manufacturers
    {
        [BsonElement("Manufacuturer")]
        public string Manufacturer { get; set; }

        [BsonElement("Disabled")]
        public bool Disabled { get; set; }
        [BsonElement("SelectionDisributionPercentage")]
        public decimal SelectionDistributionPercentage { get; set; }

        [BsonElement("OrderCount")]
        public int OrderCount { get; set; }

        [BsonElement("CalculatedDistribution")]
        public int CalculatedDistribution { get; set; }

        [BsonElement("Restrictions")]
        public Restrictions Restrictions { get; set; }

        [BsonElement("SelectionCriteria")]
        public SelectionCriteria SelectionCriteria { get; set; }
    }

}
