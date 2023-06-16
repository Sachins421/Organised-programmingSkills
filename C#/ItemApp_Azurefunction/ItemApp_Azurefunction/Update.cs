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
using MongoDB.Bson;

namespace ItemApp_Azurefunction.Modal
{
    public static class Function
    {
        [FunctionName("update")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try 
            { 
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                ActionRequest data = JsonConvert.DeserializeObject<ActionRequest>(requestBody);

                await ActionHandlerExtension.UpdateHandler(data);

                return new OkObjectResult($"Product {data.No} is udpated.");
            }
            catch (Exception ex) 
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
