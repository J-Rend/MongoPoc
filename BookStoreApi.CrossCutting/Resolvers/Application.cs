using BookStoreApi.Application;
using BookStoreApi.Domain.Abstractions.Application;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApi.CrossCutting.Resolvers
{
    public static class Application
    {
        public static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IBookApplication, BookApplication>();
        }
    }
}
