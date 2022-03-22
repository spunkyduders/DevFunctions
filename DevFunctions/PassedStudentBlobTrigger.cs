using System;
using System.IO;
using DevFunctionsLib;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DevFunctions
{
    public class PassedStudentBlobTrigger
    {
        [FunctionName("PassedStudentBlobTrigger")]
        public void Run([BlobTrigger("passed-student-items/{name}")]string myBlob, string name, ILogger log)
        {
            string student = JsonConvert.SerializeObject(myBlob);


            log.LogInformation($"Processed Passed Student Blob Trigger:{student.ToString()}");
        }
    }
}
