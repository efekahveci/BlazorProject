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
    public const string ExchangeType = "direct";

    //User 
    public const string UserExchangeName = "UserExchange";
    public const string UserEmailChangeQueueName = "UserEmailChangeQueueName";
    //EntryCommentFav
    public const string EntryCommentFavExchangeName = "EntryCommentFavExchange";
    public const string EntryCommentFavQueueName = "EntryCommentFavQueueName";
    //EntryFav
    public const string EntryFavExchangeName = "EntryFavExchange";
    public const string EntryFavQueueName = "EntryFavQueueName";
    //Clap
    public const string ClapExchangeName = "ClapExchange";
    public const string ClapQueueName = "ClapQueueName";
    //Fav
    public const string DeleteFavExchangeName = "DeleteFavExchange";
    public const string DeleteFavQueueName = "DeleteFavQueueName";
    //DeleteClap
    public const string DeleteClapExchangeName = "DeleteClapExchange";
    public const string DeleteClapQueueName = "DeleteClapQueueName";
    //CommentClap
    public const string CommentClapExchangeName = "CommentClapExchange";
    public const string CommentClapQueueName = "CommentClapQueueName";


}
