using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ToDoItems.Common;

namespace ToDoItems.ServiceBus.Woker
{
    public class WriteCosmosDb
    {
        [FunctionName("WriteCosmosDb")]
        public async Task Run([ServiceBusTrigger("todoitemqueue", Connection = "ServiceBusConStr")] ToDoItem todoItem,
        [CosmosDB(databaseName: "moongazing", containerName:"tblToDoItems" ,Connection = "CosmosDbConnStr")] IAsyncCollector<dynamic> todoItemsCollector,
        ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {todoItem}");
            await todoItemsCollector.AddAsync(todoItem);
        }

       

    }
}
