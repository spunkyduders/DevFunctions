using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DevFunctionsLib;
using System.Net.Http;
using System.Net;

namespace DevFunctions
{
    public static class StudentHttpTrigger
    {
        [FunctionName("StudentHttpTrigger")]
        [return: Queue("student-items")]
        public static async Task<Student> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            //[Queue("student-items")]IAsyncCollector<Student> studentQueue,            
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            Student student=await req.Content.ReadAsAsync<Student>();

            //await studentQueue.AddAsync(student);
            return student;
            //return req.CreateResponse(HttpStatusCode.OK, "Test");
            }
    }
}
