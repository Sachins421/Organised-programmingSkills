using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ItemApp_Azurefunction.Action;
using ItemApp_Azurefunction.Modal;

namespace ItemApp_Azurefunction
{
    public class Read
    {
        private ItemHandler _itemHandler;
        public Read(ItemHandler itemHandler) 
        {
            _itemHandler = itemHandler; 
        }
        [FunctionName("Read")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try 
            { 
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                ActionRequest data = JsonConvert.DeserializeObject<ActionRequest>(requestBody);
                //await ActionHandlerExtension.ReadHandler(data);
                return new OkObjectResult(await ActionHandlerExtension.ReadHandler(data, _itemHandler));
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
