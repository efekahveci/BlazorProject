﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BlazorProject.Common.Queue;
public  static class QueueFactory
{
    
    public static void SendMesaageToExchange(string exchangeName, string exchangeType, string queueName,object obj)
    {
        var channel = CreateBasicConsumer().EnsureExchange(exchangeName, exchangeType).EnsureQueue(queueName, exchangeName).Model;

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));

        channel.BasicPublish(exchangeName,queueName,null,body);
    }

    public static EventingBasicConsumer CreateBasicConsumer()
    {
       
        var factory = new ConnectionFactory() { HostName = RabbitMQConstans.Hostname };
        var conn = factory.CreateConnection();
        var channel = conn.CreateModel();

        return new EventingBasicConsumer(channel);

    }
    public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer,string exchangeName, string exchangeType= "direct")
    {
        consumer.Model.ExchangeDeclare(exchangeName, exchangeType, false, false);
        return consumer;
    }

    public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer, string queueName, string exchangeName)
    {
        consumer.Model.QueueDeclare(queueName, false, false, false, null);
        consumer.Model.QueueBind(queueName, exchangeName, queueName);
        return consumer;
    }
}
