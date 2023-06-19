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
using ItemApp_Azurefunction.Command;
using MediatR;

namespace ItemApp_Azurefunction.Modal
{
    public class Update
    {
        private IMediator _iMediator;

        public Update(IMediator iMediator)
        {
            _iMediator = iMediator;
        }

        [FunctionName("update")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try 
            { 
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                UpdateCommand data = JsonConvert.DeserializeObject<UpdateCommand>(requestBody);

                await _iMediator.Send(data);

                return new OkObjectResult($"Product {data.No} is udpated.");
            }
            catch (Exception ex) 
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
