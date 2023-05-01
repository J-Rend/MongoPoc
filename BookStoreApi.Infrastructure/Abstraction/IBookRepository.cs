using BookStoreApi.Domain.Entities;
using BookStoreApi.Infrastructure.Abstraction.Base;

namespace BookStoreApi.Infrastructure.Abstraction
{
    public interface IBookRepository : IRepository<Book>
    {

    }
}
