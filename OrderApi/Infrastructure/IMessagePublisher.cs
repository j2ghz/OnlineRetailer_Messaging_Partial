using System;
namespace OrderApi.Infrastructure
{
    public interface IMessagePublisher
    {
        void PublishOrderStatusChangedMessage(int productId, int quantity, string topic);
    }
}
