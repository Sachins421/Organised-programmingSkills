using ItemApp_Azurefunction.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Command
{
    public static class UpdateCommandToProduct
    {
        // Extension class of UpdateCommand class
        public static ProductModel ToModel(this UpdateCommand product)
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
