using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class Manufacturers
    {
        public string Manufacturer { get; set; }
        public bool Disabled { get; set; }
        public decimal SelectionDistributionPercentage { get; set; }
        public  int OrderCount { get; set; }
        public int CalculatedDistribution { get; set; }
        public Restrictions Restrictions { get; set; }
        public SelectionCriteria SelectionCriteria { get; set; }
    }

}
