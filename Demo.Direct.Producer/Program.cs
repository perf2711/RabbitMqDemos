﻿using Demo.Config;
using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace Demo.Direct.Producer
{
    class Program
    {
        // Argument 1: log severity
        // Argument 2: message
        static void Main(string[] args)
        {
            var factory = Connection.GetConnectionFactory();
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "direct_logs",
                                        type: "direct");

                var severity = (args.Length > 0) ? args[0] : "info";
                var message = (args.Length > 1)
                              ? string.Join(" ", args.Skip(1).ToArray())
                              : "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "direct_logs",
                                     routingKey: severity,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
