using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BlazorProject.Common.Queue;
public  class QueueFactory
{
    public static void SendMesaage(string exchangeName, string exchangeType, string queueName,object obj)
    {
        var consumer = CreateBasicConsumer();
    }

    public static EventingBasicConsumer CreateBasicConsumer(IConfiguration configuration)
    {
        var factory = new ConnectionFactory() { HostName = configuration["Auth"], Port = 4444, };
        var conn = factory.CreateConnection();
        var channel = conn.CreateModel();

        return new EventingBasicConsumer(channel);

    }
    public static EventingBasicConsumer EnsureExchange()
    {

    }
}
