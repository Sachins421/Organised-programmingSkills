using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class CartItem
    {
        public Product Product { get; set; }    
        public int quantity { get; set; }
        public decimal TotalPrice => Product.ProductPrice * quantity;    
    }
}
