using ItemApp_Azurefunction.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Action
{
     public static class CommandToProduct
    {
        // Extension class of Command class
        public static ProductModel ToModel(this CreateCommand product)
        {
            return new ProductModel
            {
                Id = product.No,
                No = product.No,
                ItemName = product.ItemName,
                Quantity = product.Quantity,
                Price = product.Price,
            };
        }
    }
}
