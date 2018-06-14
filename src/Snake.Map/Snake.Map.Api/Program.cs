using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Snake.Gameloop.Contracts;

namespace Snake.Map.Api
{
    public class Program
    {
        public static int TickCount = 0;
        public static void Main(string[] args)
        {
            var busControl = ConfigureBus();
            busControl.Start();

            CreateWebHostBuilder(args).Build().Run();
            busControl.Stop();
        }

        static IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
               {
                   h.Username("guest");
                   h.Password("guest");
               });

                cfg.ReceiveEndpoint(host, "tick", e =>
                {
                    e.Consumer<TickConsumer>();
                });
            });
        }

        public class TickConsumer : IConsumer<Tick>
        {
            public Task Consume(ConsumeContext<Tick> context)
            {
                Program.TickCount++;
                return Task.CompletedTask;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5002")
                .UseStartup<Startup>();
    }
}
