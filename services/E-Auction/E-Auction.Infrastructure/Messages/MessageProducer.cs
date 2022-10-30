using E_Auction.Domain;
using E_Auction.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace E_Auction.Infrastructure.Messages
{
    public class MessageProducer : IMessageProducer
    {
        private RabbitMq _options;
        public MessageProducer(IOptions<RabbitMq> options)
            {
             _options= options.Value;
            }

        private IModel GetConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                UserName = _options.User,
                Password = _options.Password
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("placebids", durable: true, exclusive: false, autoDelete: false, arguments: null);
            return channel;
        }
        public void SendMessage<T>(T message)
        {
            var channel = GetConnection();
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);            
            channel.BasicPublish(exchange: "", routingKey: "placebids", body: body);
        }

        public T GetMessage<T>()
        {
            dynamic result = null;
            var channel = GetConnection();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                result = JsonConvert.DeserializeObject(message);
            };
            channel.BasicConsume("placebids", true, consumer);
            return result;
        }
    }
}
