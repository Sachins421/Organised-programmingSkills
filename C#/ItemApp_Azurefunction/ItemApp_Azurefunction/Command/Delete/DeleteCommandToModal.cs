using ItemApp_Azurefunction.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Command.Delete
{
    public static class DeleteCommandToModal
    {
        //obsolete
        public static ProductModel ToModal(this DeleteCommand deleteCommand) => new ProductModel()
        {
            No = deleteCommand.No,
            Id = deleteCommand.Id,
            ItemName = deleteCommand.ItemName,
            Price = deleteCommand.Price,
            Quantity = deleteCommand.Quantity
        };
    }
}
