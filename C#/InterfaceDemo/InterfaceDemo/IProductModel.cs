using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public interface IProductModel
    {
        //Members in interface are public by default
        string Title { get; set; }
        bool HasOrderBeenCompleted { get; }
        void ShipOrder(CustomerModel customerModel);
    }
}
