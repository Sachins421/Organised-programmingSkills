using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Messaging.EventGrid;
using Azure;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using System.Net;

namespace EventGridApp
{
    public static class SendEventGridToTopics
    {
        [FunctionName("SendEventGridToTopics")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = null)] HttpRequest req,
            ILogger log)
        {

            log.LogInformation("C# HTTP trigger function processed a request.");

            string eventGridEndpoint = Environment.GetEnvironmentVariable("EventGridEndpoint");
            string eventGridKey = Environment.GetEnvironmentVariable("EventGridKey");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string responseMessage = "";
            string eventType = data.eventType;
            string dataVersion = data.dataVersion;
            string topic = data.topic;

            if (eventType == "") return new BadRequestResult();
            if (topic == "") return new BadRequestResult();

            var message = new MyEventData { Message = data.data.message  }; // Convert message to stronly typed object the matches the structure of event data

            try {
                var crdential = new AzureKeyCredential(eventGridKey);
                var EventClient = new EventGridPublisherClient(new Uri(eventGridEndpoint), crdential);
                var eventGridEvent = new EventGridEvent("Testing", eventType, dataVersion, message);

                eventGridEvent.Topic = data.topic;
                eventGridEvent.Id = Guid.NewGuid().ToString();
                eventGridEvent.EventTime = DateTime.Now;
                responseMessage = $"Hello, {eventGridEvent.Id}. This HTTP triggered function executed successfully.";
                log.LogInformation($"Processing request...{data}");

                await EventClient.SendEventAsync(eventGridEvent);
            }

            catch (Exception ex)
            {
                log.LogInformation("Processing request...");
                log.LogError("An error occurred: {errorMessage}", ex.Message);
            }

            return new OkObjectResult(responseMessage);
        }
    }
}
