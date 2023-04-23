using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ReadAzureServiceBusMessages
{
    public class ReadMessagesBusTrigger
    {
        [FunctionName("ReadMessagesBusTrigger")]
        public void Run([ServiceBusTrigger("test-me-queue", Connection = "ServiceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
