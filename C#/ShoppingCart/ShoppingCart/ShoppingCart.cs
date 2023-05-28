using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        public List<CartItem> cart;
        private bool ValidItem;
        public ShoppingCart() { 
            Console.WriteLine("Consturtor called.");
            cart = new List<CartItem>();
        }


        public void ValidateItem(string items)
        {
            foreach (var item in cart)
            {
                if (items != null && items == item.Product.ProductName)
                {
                    ValidItem = true;
                    if (ValidItem)
                    {
                        break;
                    }
                }
            }
            if (!ValidItem)
            {
                throw new Exception("Invalid item.");
            }
        }
    }
}
