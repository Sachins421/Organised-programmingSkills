using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateApp
{
    class Program
    {
        static ShoppingCartModel shoppingCartModel = new ShoppingCartModel();
        public delegate void DelgateAsParameter(string msg); // Another way to create and call delgate

        public static void Main(string[] args)
        {
            populateCart();
            Console.WriteLine($"The total amount of the cart after discount is {shoppingCartModel.Subtotal(ShowSubToal, CalculateDiscountOnSubtotalAmount):C2}");

            // // Another way to create and call delgate
            Console.WriteLine("-------");
            DelgateAsParameter del = Class_A.MethodA; 
            invokeDelegat(del);

            del = Class_B.MethodB;
            invokeDelegat(del);


            // Func delegate
            Func<int, int, decimal> add;
            add = sum;

            Console.WriteLine(add(1,5));

            Console.ReadLine();

        }

        static decimal sum(int x, int y)
        {
            return x + y;
        }

        public static void invokeDelegat(DelgateAsParameter del)
        {
            del("Method invokeDelegat is called: Hello world.");
        }

        private static void ShowSubToal(decimal DiscountAlert) 
        {
            //string formattedValue = DiscountAlert.ToString("C2", new CultureInfo("de-DE")); //Currency formatter
            Console.OutputEncoding = System.Text.Encoding.Unicode; //Encoding to show Euro currency symbol
            Console.WriteLine($"The subtotal of the card is {DiscountAlert:C2}"); // Do not keep space {DiscountAlert:C2}
        }


        // Method for Func delegate for Subtotal method 
        private static Decimal CalculateDiscountOnSubtotalAmount(List<ShopModel> shopModel, Decimal subTotalAmount) 
        {
            if (subTotalAmount < 50)
            {
                return subTotalAmount * 0.80M;
            }
            else if (subTotalAmount > 50)
            {
                return subTotalAmount * 0.100M;
            }
            else
                return subTotalAmount;
        }

        private static void populateCart()
        {
            shoppingCartModel.Items.Add(new ShopModel { ItemName = "Milk", price = 1.5M });
            shoppingCartModel.Items.Add(new ShopModel { ItemName = "Avacado", price = 3.5M });
            shoppingCartModel.Items.Add(new ShopModel { ItemName = "Apple", price = 3.5M });
            shoppingCartModel.Items.Add(new ShopModel { ItemName = "Bread", price = 2.5M });
        }
    }
}
