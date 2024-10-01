using WMS.Enums;

namespace wms.core.Models;
public class Product
{
    public string ProductId { get; set; }
    public string Name { get; set;}
    public string Description { get; set;}
    public decimal Price { get; set; }
    public decimal Cost {get; set;}
    public decimal Inventory { get; set; }
    public ProductCategory productCategory { get; set; }
    public bool Blocked { get; set; }

}
