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

namespace ItemApp_Azurefunction
{
    public static class Read
    {
        [FunctionName("Read")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try 
            { 
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                ActionRequest data = JsonConvert.DeserializeObject<ActionRequest>(requestBody);

                //await ActionHandlerExtension.ReadHandler(data);

                return new OkObjectResult(await ActionHandlerExtension.ReadHandler(data));
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
