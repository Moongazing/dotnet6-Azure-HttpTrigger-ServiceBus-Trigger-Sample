using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ToDoItems.Common;

namespace ToDoItems.Ingress.API
{
    public static class CreateToDo
    {
        [FunctionName("CreateToDo")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/CreateToDo")] HttpRequest req,
        [ServiceBus(queueOrTopicName: "todoitemqueue", Connection = "ServiceBusConStr")] IAsyncCollector<dynamic> serviceBusCollector,
        ILogger log)
        {
            var bodyJson = await req.ReadAsStringAsync();
            var todoItem = System.Text.Json.JsonSerializer.Deserialize<ToDoItem>(bodyJson);

            await serviceBusCollector.AddAsync(todoItem);

            return new OkObjectResult("ToDoItem added to servicebus successfully.");
        }
    }
}
