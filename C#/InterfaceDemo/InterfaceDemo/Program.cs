using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IProductModel> products = PopulateCart();
            var customer = GetCustomer();

            foreach(IProductModel prod in products)
            {
                prod.ShipOrder(GetCustomer());
             
            }
            if (products.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Order is completed.");
            }
        }

        static CustomerModel GetCustomer()
        {
            var customer = new CustomerModel()
            {
                Id = 1,
                Name = "John",
                Address = "X Strasse",
                City = "Berlin",
                Region = "South",
                PostalCode = "10318",
                Country = "Germany"
            };
            return customer;
        }

        static List<IProductModel> PopulateCart()
        {
            var product = new List<IProductModel>();
            product.Add(new GroceryModel { Title = "Milk" });
            product.Add(new GroceryModel { Title = "Veg" });
            product.Add(new GroceryModel { Title = "Bread" });
            product.Add(new GroceryModel { Title = "Curd" });
            product.Add(new ElectronicModel { Title = "Pen drive" });
            product.Add(new ElectronicModel { Title = "Keyboard" });
            product.Add(new ElectronicModel { Title = "Docker" });

            return product;
        }
    }
}
