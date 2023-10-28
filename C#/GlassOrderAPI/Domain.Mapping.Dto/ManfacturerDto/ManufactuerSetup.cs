using Model.Data.Models.ManufacturerSetup;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.ManfacturerDto
{
    public class ManufactuerSetup
    {
        public BaseData BaseData { get; set; }
        public ServicePrice[] ServicePrices { get; set; }
        public DecisionMapping DecisionMapping { get; set; }

        public ManGlassPackageMapping[] ManGlassPackageMapping { get; set; }
        public ManGlassCodeMapping[] ManGlassCodeMapping { get; set; }
        public AutoselectFilterChecks AutoselectFilterChecks { get; set; }
    }
}
