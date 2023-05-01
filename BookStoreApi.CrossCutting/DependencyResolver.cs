using BookStoreApi.CrossCutting.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApi.CrossCutting
{
    public static class DependencyResolver
    {

        public static void RegisterDependencies(this IServiceCollection services)
        {
            Resolvers.Infrastructure.RegisterRepositories(services);
            Resolvers.Infrastructure.RegisterContext(services);

            Resolvers.Application.RegisterApplications(services);
            Resolvers.Service.RegisterServices(services);
        }

    }
}
