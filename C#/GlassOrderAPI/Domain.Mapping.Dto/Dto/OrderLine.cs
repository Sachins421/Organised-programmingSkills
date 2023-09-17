using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto    
{
    public class OrderLine
    {
        public string type { get; set; }
        public string No { get; set; }
        public int LineNo { get; set; }
        public decimal Quantity { get; set; }
        public string ItemCategory { get; set; }
    }
}
