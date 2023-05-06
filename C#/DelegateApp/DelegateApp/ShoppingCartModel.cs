using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateApp
{
    public delegate void ShoppingCartItemDelegate(decimal subTotal); //  A delegate can be declared outside of the class or inside the class.
                                                                     //  Practically, it should be declared out of the class.
    class ShoppingCartModel
    {
        public List<ShopModel> Items;

        public ShoppingCartModel() 
        {
            Items = new List<ShopModel>();  
        }

        public decimal Subtotal(ShoppingCartItemDelegate shoppingCartItemDelegate, Func<List<ShopModel>,Decimal,Decimal> CalculateTotalDiscount)
        {
            decimal subTotalAmount = Items.Sum(x => x.price);

            shoppingCartItemDelegate(subTotalAmount);

            return CalculateTotalDiscount(Items, subTotalAmount);
        }
    }
}
