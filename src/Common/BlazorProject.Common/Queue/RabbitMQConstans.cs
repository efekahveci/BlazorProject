using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Queue;
public static class RabbitMQConstans
{
    public const string Hostname = "localhost";
    public const int Port = 15672;
    public const string UserExchangeName = "UserExchange";

    public const string UserEmailChangeQueueName = "UserEmailChangeQueueName";
    public const string ExchangeType = "direct";




}
