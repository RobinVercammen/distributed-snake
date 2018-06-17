using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Snake.Gameloop.Contracts;

namespace Snake.Gameloop
{
    internal class Program
    {
        private static readonly Guid SnakeId = Guid.Parse("27524dc8-5778-422e-91d9-6016173d11eb");
        private static readonly SnakePostion Head = new SnakePostion {X = 5, Y = 5};

        private const string ServiceBusConnectionString =
            "Endpoint=sb://disctributed-snake-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9F7E91nb2/vEsCPFoRlyvnU+leERdQTDmYRuyzgHfcI=";

        private const string QueueName = "tick";
        private static IQueueClient queueClient;

        private static async Task Main(string[] args)
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            Process.GetCurrentProcess().Exited += (sender, eventArgs) =>
            {
                Console.WriteLine("Closing bus connections");
                queueClient.CloseAsync().GetAwaiter().GetResult();
            };
            var seq = 0;
            while (true)
            {
                var msg = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new UpdateSnake()
                {
                    Id = SnakeId,
                    Postions = new SnakePostion[] {new SnakePostion {X = Head.X, Y = Head.Y++}}
                })));
                await queueClient.SendAsync(msg);
                await Task.Delay(1000);
            }
        }
    }
}