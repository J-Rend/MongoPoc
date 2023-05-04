using BookStoreApi.Infrastructure.Abstraction;

namespace BookStoreApi.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {

        IBookRepository Books { get; }

    }
}
