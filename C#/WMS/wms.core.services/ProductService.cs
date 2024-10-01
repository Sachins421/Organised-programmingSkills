using wms.core.Models;

namespace wms.core.services
{
    public class ProductService : IProductService
    {
        public List<Product> _products = new();
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void DeleteProduct(string id)
        {
            var product = GetProductById(id);
            _products.Remove(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(string ProductId)
        {
           return _products.Where(p => p.ProductId == ProductId).FirstOrDefault();
           //return _products.FirstOrDefault(p => p.ProductId == ProductId);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Blocked = product.Blocked;
                existingProduct.Description = product.Description;
                existingProduct.productCategory = product.productCategory;
                existingProduct.Blocked = product.Blocked;
                existingProduct.Price = product.Price;
            }
        }
    }
}