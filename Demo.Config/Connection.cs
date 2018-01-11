using System;
using RabbitMQ.Client;

namespace Demo.Config
{
    public class Connection
    {
        public const string Hostname = "172.104.152.111";
        public const string Username = "ktbdays";
        public const string Password = "ktbdays";

        public static ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = Hostname,
                UserName = Username,
                Password = Password
            };
        }
    }
}
