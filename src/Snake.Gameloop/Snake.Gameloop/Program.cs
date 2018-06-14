using System;
using System.Threading;
using MassTransit;
using Snake.Gameloop.Contracts;

namespace Snake.Gameloop
{
    class Program
    {
        static void Main(string[] args)
        {
            var busControl = ConfigureBus();
            busControl.Start();

            while (true)
            {
                busControl.Publish<Tick>(new Tick());
                Thread.Sleep(100);
            }

            busControl.Stop();
        }

        static IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
               {
                   h.Username("guest");
                   h.Password("guest");
               });
            });
        }
    }
}
