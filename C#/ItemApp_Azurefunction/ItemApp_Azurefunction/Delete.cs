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
using MediatR;
using ItemApp_Azurefunction.Command.Delete;

namespace ItemApp_Azurefunction
{
    public class Delete
    {
        private IMediator _imediator;
        public Delete(IMediator imediator)
        {
            _imediator = imediator;
        }

        [FunctionName("Delete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                DeleteCommand data = JsonConvert.DeserializeObject<DeleteCommand>(requestBody);

                await _imediator.Send(data);

                return new OkObjectResult($"Product {data.No} is deleted.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
