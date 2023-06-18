using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Xml.Linq;
using ItemApp_Azurefunction.Action;
using ItemApp_Azurefunction.Modal;

namespace ItemApp_Azurefunction
{
    public class Delete
    {
        private ItemHandler _itemHandler;
        public Delete(ItemHandler itemHandler) 
        {
            _itemHandler = itemHandler;    
        }
        [FunctionName("Delete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                ActionRequest data = JsonConvert.DeserializeObject<ActionRequest>(requestBody);
                
                await ActionHandlerExtension.DeleteHandler(data, _itemHandler);

                return new OkObjectResult($"Product {data.No} is deleted.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
