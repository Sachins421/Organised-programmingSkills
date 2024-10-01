using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using wms.core.Models;
using wms.core.services;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main(string[] args)
//     {
//         //string con = "Server=localhost,1433;Database=WMSDb;User Id=SA;Password=YourStrong!Passw0rd;";
//         string con = "Server=localhost,1433;Database=WMSDb;User Id=SA;Password=YourStrong!Passw0rd;TrustServerCertificate=True;Encrypt=False";
//         using (SqlConnection connection = new SqlConnection(con))
//         {
//             try
//             {
//                 connection.Open();
//                 Console.WriteLine("Connection successful!");
//                 connection.Close();
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Error: {ex.Message}");
//             }
//         }
//     }
// }


var builder = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("settings.json", optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddDbContext<WMSContext>(options =>
                    options.UseSqlServer(hostingContext.Configuration.GetConnectionString("WMSDatabase")));

                services.AddSingleton<IProductService, ProductService>();
            })
            .UseConsoleLifetime();  

var serviceProvider = new ServiceCollection().AddSingleton<IProductService,ProductService>().BuildServiceProvider();
var productService = serviceProvider.GetService<IProductService>();

var product = new Product() 
{
    ProductId = "23435",
    Name = "test item"
};

productService.AddProduct(product);

var products = productService.GetAllProducts();

foreach(var p in products)
{
    System.Console.WriteLine($"productid {product.ProductId} and Name {product.Name}");
}

