using System.Net;
using WMS.Enums;

namespace wms.core.Models
{
    public class Order
    {
        public string OrderNo { get; set; }
        public DocumentType Type {get; set;}
        public string ExternalDocumentNo { get; set; }
        public OrderStatus orderStatus { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Createdby {get; set;} 
        public List<OrderLines> OrderLines { get; set; }
    }
}