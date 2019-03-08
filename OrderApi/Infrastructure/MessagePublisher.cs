using System;
using EasyNetQ;
using SharedModels;

namespace OrderApi.Infrastructure
{
    public class MessagePublisher : IMessagePublisher, IDisposable
    {
        IBus bus;

        public MessagePublisher(string connectionString)
        {
            bus = RabbitHutch.CreateBus(connectionString);
        }

        public void Dispose()
        {
            bus.Dispose();
        }

        public void PublishOrderStatusChangedMessage(int productId, int quantity, string topic)
        {
            var message = new OrderStatusChangedMessage
            { ProductId = productId, Quantity = quantity };

            bus.Publish(message, topic);
        }
    }
}
