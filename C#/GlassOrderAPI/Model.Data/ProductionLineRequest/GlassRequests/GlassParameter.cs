using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.ProductionLineRequest.GlassRequests
{
    public class GlassParameter
    {
        [BsonElement(nameof(CorrectionValue))]
        public CorrectionValue CorrectionValue { get; set; }

        [BsonElement(nameof(PackageValues))]
        public PackageValues PackageValues { get; set; }    
    }
}
