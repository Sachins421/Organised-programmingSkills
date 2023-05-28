using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ShoppingCart
{
    class Program
    {
        static ShoppingCart shoppingcart = new ShoppingCart();
        public static void Main(string[] args)
        {
            decimal totalprice = 0;
            GetAllItems();
            HttpClient _httpClient = new HttpClient();

            [HttpGet, Route("DotNetCount")]
             async Task<int> GetDotNetCount()
            {
                // Suspends GetDotNetCount() to allow the caller (the web server)
                // to accept another request, rather than blocking on this one.
                var html = await _httpClient.GetStringAsync("https://dotnetfoundation.org");
                return Regex.Matches(html, @"\.NET").Count;
            }

            Console.WriteLine("Welcome to the E-Kart online shopping!");
            Console.WriteLine("These are the bleow items you can order.");
            foreach (var item in shoppingcart.cart)
            {
                Console.WriteLine($"Product: {item.Product.ProductId} : {item.Product.ProductName} Expiry : {item.Product.ProductExpiry}");
                totalprice += item.TotalPrice;
            }
            string value = "";
            Console.WriteLine("");
            while ((value) != "End")
            {
                Console.WriteLine("Please enter the productoin.");
                var ItemNo = Console.ReadLine();
                shoppingcart.ValidateItem(ItemNo);
                Console.WriteLine("Please enter the Quantity.");
                var ItemQty = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter 'End' to chceckout.");
                value = Console.ReadLine();
            }


            Console.WriteLine("total price is: "+ totalprice);

            Console.ReadLine();
        }

        public static void GetAllItems()
        {
            
            shoppingcart.cart.Add(new CartItem { Product = (new Product
                                    {
                                        ProductId = new Random().Next(1, 10),
                                        ProductName = "Milk",
                                        ProductExpiry = DateTime.Now.AddDays(14).ToString(),
                                        ProductPrice = 1.5m
                                    })
                                ,quantity = 3 });
            shoppingcart.cart.Add(new CartItem
            {
                Product = (new Product
                {
                    ProductId = new Random().Next(1, 10),
                    ProductName = "Bread",
                    ProductExpiry = DateTime.Now.AddDays(14).ToString(),
                    ProductPrice = 1.5m
                })
                                                           ,
                quantity = 4
            });
            shoppingcart.cart.Add(new CartItem
            {
                Product = (new Product
                {
                    ProductId = new Random().Next(1, 10),
                    ProductName = "Wheat",
                    ProductExpiry = DateTime.Now.AddDays(14).ToString(),
                    ProductPrice = 3.5m
                })
                                                          ,
                quantity = 4
            });
            shoppingcart.cart.Add(new CartItem
            {
                Product = (new Product
                {
                    ProductId = new Random().Next(1, 10),
                    ProductName = "Oats",
                    ProductExpiry = DateTime.Now.AddDays(14).ToString(),
                    ProductPrice = 2.4m
                })
                                                          ,
                quantity = 4
            });
        }
      
    }
}

