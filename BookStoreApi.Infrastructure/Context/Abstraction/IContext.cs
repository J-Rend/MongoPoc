using BookStoreApi.Domain.Entities.Base;
using MongoDB.Driver;

namespace BookStoreApi.Infrastructure.Context.Base
{
    public interface IContext
    {
        IMongoCollection<T> GetMongoCollection<T>() where T : Entity;

    }
}
