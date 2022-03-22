using System;
using DevFunctionsLib;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace DevFunctions
{
    public  class StudentSbTrigger
    {
        [FunctionName("StudentSBTrigger")]
        
        public void Run([ServiceBusTrigger("funcportalq", Connection = "AzureServiceBusConn")]string myQueueItem,
            [Queue("student-items")] out string studentQueue,
            ILogger log)
        {
            studentQueue = myQueueItem;
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
