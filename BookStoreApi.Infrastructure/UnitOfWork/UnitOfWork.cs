using BookStoreApi.Infrastructure.Abstraction;
using BookStoreApi.Infrastructure.Context.Base;
using BookStoreApi.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApi.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        public IBookRepository Books { get { return new BookRepository(Context); }}
        public IContext Context;

        public UnitOfWork(IContext context)
        {
            Context = context;
        }

    }
}
