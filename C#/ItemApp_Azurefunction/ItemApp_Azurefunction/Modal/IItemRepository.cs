using ItemApp_Azurefunction.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Modal
{
    public interface IItemRepository
    {
        Task Create(ProductModel productModel);
        Task Update(string productid, ProductModel productModel);
        Task<List<ProductModel>> Read(string productid);
        Task Delete(string productid);
    }
}
