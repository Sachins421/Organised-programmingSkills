using wms.core.Models;

namespace wms.core.services;

public interface IProductService
{
    List<Product> GetAllProducts();
    Product GetProductById(string ProductId);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(string id);
}
