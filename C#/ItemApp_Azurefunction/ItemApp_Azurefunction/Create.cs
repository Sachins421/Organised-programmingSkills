using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatR;
using ItemApp_Azurefunction.Action;

namespace ItemApp_Azurefunction
{
    public class Create
    {
        private IMediator _imediator;

        public Create(IMediator mediator) 
        {
            _imediator = mediator;
        }

        [FunctionName("Create")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // Command Query Responsibility Segregation (CQRS)
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                CreateCommand data = JsonConvert.DeserializeObject<CreateCommand>(requestBody); //cast to oject ProductModel

                await _imediator.Send(data);

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
