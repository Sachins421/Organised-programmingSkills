using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public class ElectronicModel : IProductModel
    {
        public string Title { get; set; }

        public bool HasOrderBeenCompleted { get; set; }

        public void ShipOrder(CustomerModel customerModel)
        {
            Console.WriteLine($"Order {Title} is being shipped to the customer {customerModel.Name} and to the address {customerModel.Address}");
           
        }
    }
}
