using BookStoreApi.Domain.Entities.Base;

namespace BookStoreApi.Infrastructure.Abstraction.Base
{
    public interface IRepository<T> where T : Entity
    {

        Task<IEnumerable<T>> GetAsync(int? totalItems, CancellationToken cancellationToken);

        Task<T?> GetAsync(string id, CancellationToken cancellationToken);

        Task CreateAsync(T newEntity, CancellationToken cancellationToken);

        Task UpdateAsync(string id, T updatedEntity, CancellationToken cancellationToken);

        Task RemoveAsync(string id, CancellationToken cancellationToken);

    }
}
