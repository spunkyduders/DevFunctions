using DevFunctionsLib;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Azure.EventHubs;

//SBQueueMessageSender().Wait();
//SBTopicMessageSender().Wait();
EventHubMessageSender().Wait();

async Task SBQueueMessageSender()
{
    string sbConnStr = "Endpoint=sb://funcportal.servicebus.windows.net/;SharedAccessKeyName=Manage;SharedAccessKey=Dw/TtEBZZjpX75zyIpIyRoqqW9b5KuMV7MSFTi5sQnQ=;";
    QueueClient client = new(sbConnStr, "funcportalq", ReceiveMode.ReceiveAndDelete, null);
    Student s = new Student("Rajasekhar", 260);
    var studentstr = JsonConvert.SerializeObject(s);
    Message m = new Message(Encoding.UTF8.GetBytes(studentstr));
    await client.SendAsync(m);
    Console.WriteLine("Message sent successfully!");

}
async Task SBTopicMessageSender()
{
    string sbConnStr = "Endpoint=sb://funcportal.servicebus.windows.net/;SharedAccessKeyName=Manage;SharedAccessKey=Dw/TtEBZZjpX75zyIpIyRoqqW9b5KuMV7MSFTi5sQnQ=;";
    QueueClient client = new(sbConnStr, "funcportalq", ReceiveMode.ReceiveAndDelete, null);
    Student s = new Student("Rajasekhar", 260);
    var studentstr = JsonConvert.SerializeObject(s);
    Message m = new Message(Encoding.UTF8.GetBytes(studentstr));
    await client.SendAsync(m);
    Console.WriteLine("Message sent successfully!");

}


async Task EventHubMessageSender()
{
    string ehConnStr = "Endpoint=sb://funcportaleventhub.servicebus.windows.net/;SharedAccessKeyName=studentpol;SharedAccessKey=l13Q1x6AUe6FhtENJiQ1jwRXZCCjytVqfsBD6B5Y4Zw=;EntityPath=studenteventhub";

    var client = EventHubClient.CreateFromConnectionString(ehConnStr);

    List<EventData> students = new List<EventData>();
     for (int i = 20; i < 100; i += 5)
    {

        Student s = new Student("Rajasekhar", i);
        string studentStr = JsonConvert.SerializeObject(s);
        EventData data = new EventData(Encoding.UTF8.GetBytes(studentStr));

        students.Add(data);
    }
    await client.SendAsync(students);
    Console.WriteLine("Message sent successfully!");

}

