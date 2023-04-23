using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Messaging.ServiceBus;
using System.Text;
using Microsoft.Azure.ServiceBus;

namespace ReadAzureServiceBusMessages
{
    public static class PushMessagesToBus
    {
        [FunctionName("PushMessagesToBus")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Message pushed successfully!");

            string queueName = req.Query["queueName"];

            var connectionString = Environment.GetEnvironmentVariable("ServiceBusConnectionString");
            await using var client = new ServiceBusClient(connectionString);
            var queueClient = new Microsoft.Azure.ServiceBus.QueueClient(connectionString, queueName);
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Message message = new Message(Encoding.UTF8.GetBytes(requestBody));

            await queueClient.SendAsync(message);

            return new OkResult();
        }
    }
}
