using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Snake.Gameloop.Contracts;

namespace Snake.Map.Api
{
    public class Program
    {
        public static int SnakeYPostion;

        public static void Main(string[] args)
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

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var msg = Encoding.UTF8.GetString(ea.Body);

                        var snake = JsonConvert.DeserializeObject<UpdateSnake>(msg);

                        SnakeYPostion = snake.Postions[0].Y;
                    };
                    channel.BasicConsume("tick",
                        true,
                        consumer);
                    CreateWebHostBuilder(args).Build().Run();
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5002")
                .UseStartup<Startup>();
        }
    }
}