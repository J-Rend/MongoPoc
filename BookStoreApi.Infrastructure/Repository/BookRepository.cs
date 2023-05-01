using BookStoreApi.Domain.Entities;
using BookStoreApi.Infrastructure.Abstraction;
using BookStoreApi.Infrastructure.Context.Base;
using TStoreApi.Infrastructure.Repository.Base;

namespace BookStoreApi.Infrastructure.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(IContext context) : base(context)
        {
        }

    }
}
