using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ItemApp_Azurefunction.Query;
using MediatR;


namespace ItemApp_Azurefunction
{
    public class Read
    {
        private IMediator _imediator;
        public Read(IMediator imediator) 
        {
            _imediator = imediator; 
        }
     
        [FunctionName("Read")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try 
            { 
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                QueryR data = JsonConvert.DeserializeObject<QueryR>(requestBody);
                //await ActionHandlerExtension.ReadHandler(data);

                var result = await _imediator.Send(data);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
