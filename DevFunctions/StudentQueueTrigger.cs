using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

using DevFunctionsLib;
using Newtonsoft.Json;
namespace DevFunctions
{
    public class StudentQueueTrigger
    {
        [FunctionName("QueueTrigger")]
        public void Run([QueueTrigger("student-items")]Student studentMarks, 
            [Blob("passed-student-items/{rand-guid}")] out string passedStudent,
            [Blob("failed-student-items/{rand-guid}")] out string failedStudent,
                        ILogger log)
        {
            if (studentMarks.MarksAvg>=35)
            {
                passedStudent = JsonConvert.SerializeObject(studentMarks);
                failedStudent = null;
            }
            else
            {
                failedStudent= JsonConvert.SerializeObject(studentMarks);
                passedStudent = null;
            }
            
            log.LogInformation($"C# Queue trigger function processed:{studentMarks.ToString()}");

        }
    }
}
