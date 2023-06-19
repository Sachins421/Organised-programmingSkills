using ItemApp_Azurefunction.Modal;
using System.Collections.Generic;


namespace ItemApp_Azurefunction.Query
{
    public static class ProductModelToResponse
    {
        // Extension class of Action class
        public static Response ToModel(this List<ProductModel> request)
        {
            Response response = new Response();
            foreach (var item in request)
            {
                response.Id = item.Id;
                response.No = item.Id;
                response.ItemName = item.ItemName;
                response.Quantity = item.Quantity;
                response.Price = item.Price;
            }
            return response;
        }
            
    } 
}
