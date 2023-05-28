using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Channels;
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

            int publiceILoggerErrrorcount(ILogger logger)
            {
                return logger.ErrorCount;
            }

            Console.WriteLine("ILogger");

            var dl = new DisplayLogger();
            dl.LogError("this is the error.");
            Console.WriteLine(dl.ErrorCount);
            Console.WriteLine(publiceILoggerErrrorcount(dl));

            Console.WriteLine("Explicit implementation");
            var dbs = new DBLogger();
            //db.LogError("This is the error from main method."); // can not called.
            ILogger db = new DBLogger();
            db.LogError("This is the error from main method.");
            //Console.WriteLine(dbs.GetType()); // show same type dblogger
            //Console.WriteLine(db.GetType()); // show same type dblogger

            Console.WriteLine("********Default implementation********");
            var il = new NewThing();
            il.DoSomethingElse();
            //il.DoTheThing();

            ILogger2 IL = new NewThing();
            IL.DoTheThing(); // if not implemented then default will be called

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
