using BookStoreApi.Domain.Entities;
using BookStoreApi.Infrastructure.Abstraction;
using BookStoreApi.Infrastructure.Abstraction.Base;
using BookStoreApi.Infrastructure.Context;
using BookStoreApi.Infrastructure.Context.Base;
using BookStoreApi.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApi.CrossCutting.Resolvers
{
    public static class Infrastructure
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }

        public static void RegisterContext(IServiceCollection services) 
        {
            services.AddTransient<IContext, Context>();
        } 

    }
}
