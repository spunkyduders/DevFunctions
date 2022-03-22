using System;
using System.IO;
using DevFunctionsLib;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DevFunctions
{
    public class FailedStudentBlobTrigger
    {
        [FunctionName("FailedStudentBlogTrigger")]
        public void Run([BlobTrigger("failed-student-items/{name}")]string myBlob, 
                        string name, ILogger log)
        {
            Student student = JsonConvert.DeserializeObject<Student>(myBlob);


            log.LogInformation($"Processed Failed Student Blob Trigger:{student.ToString()}");
        }
    }
}
