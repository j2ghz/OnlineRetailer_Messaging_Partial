using System;
using SharedModels;

namespace OrderApi.Infrastructure
{
    public interface IServiceGateway<T>
    {
        T Get(int id);
    }
}
