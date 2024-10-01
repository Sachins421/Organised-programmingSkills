using WMS.Enums;

namespace wms.core.Models
{
    public class OrderLines
    {
        public string OrderNo { get; set; }
        public int LineNo { get; set; }
        public string productId { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice {get; set;}
        public ProductCategory productCategory { get; set; }
        
    }
}