using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Snake.Gameloop.Contracts;

namespace Snake.Gameloop
{
    internal class Program
    {
        private static readonly Guid SnakeId = Guid.Parse("27524dc8-5778-422e-91d9-6016173d11eb");
        private static readonly SnakePostion Head = new SnakePostion {X = 5, Y = 5};

        private static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("tick",
                        false,
                        false,
                        false,
                        null);

                    var seq = 0;
                    while (true)
                    {
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new UpdateSnake
                        {
                            Id = SnakeId,
                            Postions = new[] {new SnakePostion {X = Head.X, Y = Head.Y++}}
                        }));
                        channel.BasicPublish("",
                            "tick",
                            null,
                            body);
                        await Task.Delay(1000);
                    }
                }
            }
        }
    }
}