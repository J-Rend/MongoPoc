using BookStoreApi.Domain.Arguments.Request;
using BookStoreApi.Domain.Arguments.Response;

namespace BookStoreApi.Domain.Abstractions.Application
{
    public interface IBookApplication
    {
        Task<IEnumerable<GetBookResponse>> GetAllAsync(int? limit = 150, CancellationToken cancellationToken = default);
        Task<GetBookResponse?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task UpdateBookAsync(string id,SetBookRequest request, CancellationToken cancellationToken);
        Task DeleteBookAsync(string id, CancellationToken cancellationToken);
        Task<string?> CreateBookAsync(SetBookRequest request, CancellationToken cancellationToken);

    }
}
