using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ItemApp_Azurefunction.Modal;
using Microsoft.VisualBasic;
using ItemApp_Azurefunction.Action;
using System.Reflection.Metadata;

namespace ItemApp_Azurefunction
{
    public class Create
    {
        private ItemHandler _itemHandler;

        public Create(ItemHandler itemHandler) 
        {
            _itemHandler = itemHandler;
        }

        [FunctionName("Create")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                ActionRequest data = JsonConvert.DeserializeObject<ActionRequest>(requestBody); //cast to oject ProductModel

                await ActionHandlerExtension.CreateHandler(data, _itemHandler);

                var result = "Product created.";
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Prduction could not be created. Here is the detailed error description : \n {ex.Message}");
            }
            
        }
    }
}
