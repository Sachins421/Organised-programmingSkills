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
using System.Linq;
using System.Text;

namespace ReadAzureServiceBusMessages
{
    public static class ReadMessagesFromBus
    {
        [FunctionName("ReadMessagesFromBus")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string queueName = req.Query["queue"];
            int _NoOfMessages = int.Parse(req.Query["NoOfMessagesToRead"]);

            var connectionString = Environment.GetEnvironmentVariable("ServiceBusConnectionString");
            await using var client = new ServiceBusClient(connectionString);

            var receiver = client.CreateReceiver(queueName);
            var messages = new ServiceBusReceivedMessage[_NoOfMessages];

            var messagesreceiver = await receiver.ReceiveMessagesAsync(_NoOfMessages, TimeSpan.FromSeconds(5));

            if (messagesreceiver.Count == 0)
            {
                return new NotFoundObjectResult("No new messages found!");
            }

            return new OkObjectResult(messagesreceiver.ToList());
        }
    }
}
