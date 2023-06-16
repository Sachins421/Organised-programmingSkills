using Amazon.Runtime.Internal;
using ItemApp_Azurefunction.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Action
{
    public static class ActionHandlerExtension
    {
        public async static Task CreateHandler(ActionRequest actionRequest)
        {
            //var request = ProductToActionExtension.ToModel(); //complaing for the parameter
            var request = actionRequest.ToModel();

            await ItemHandler.Create(request);
        }

        public async static Task UpdateHandler(ActionRequest actionRequest)
        {
            //var request = ProductToActionExtension.ToModel(); //complaing for the parameter
            var request = actionRequest.ToModel();

            await ItemHandler.Update(actionRequest.No, request);
        }

        public async static Task<List<ProductModel>> ReadHandler(ActionRequest actionRequest)
        {
            //var request = ProductToActionExtension.ToModel(); //complaing for the parameter
            var request = actionRequest.ToModel();

            return await ItemHandler.Read(actionRequest.No);
        }

        public async static Task DeleteHandler(ActionRequest actionRequest)
        {
            //var request = ProductToActionExtension.ToModel(); //complaing for the parameter
            var request = actionRequest.ToModel();

            await ItemHandler.Delete(actionRequest.No);
        }
    }
}
