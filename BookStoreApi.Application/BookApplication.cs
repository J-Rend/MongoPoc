using BookStoreApi.Domain.Abstractions.Application;
using BookStoreApi.Domain.Arguments.Request;
using BookStoreApi.Domain.Arguments.Response;
using BookStoreApi.Domain.Entities;
using BookStoreApi.Infrastructure.Abstraction;
using BookStoreApi.Domain.Arguments.Response.Adapters;

namespace BookStoreApi.Application
{
    public class BookApplication : IBookApplication
    {
        private IBookRepository _bookRepository;

        public BookApplication(IBookRepository bookRepository)
        {
            ArgumentNullException.ThrowIfNull(bookRepository, nameof(bookRepository));

            _bookRepository = bookRepository;

        }

        public async Task<string?> CreateBookAsync(SetBookRequest request, CancellationToken cancellationToken)
        {
            var entity = new Book(request);

            if (entity.IsInvalid)
                return null;

            await _bookRepository.CreateAsync(entity, cancellationToken);

            return entity.Id;

        }

        public Task DeleteBookAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetBookResponse>> GetAllAsync(int? limit = 150, CancellationToken cancellationToken = default)
        {
            var response = await _bookRepository.GetAsync(limit, cancellationToken);

            return response.AdaptToResponse();
        }

        public Task<GetBookResponse> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAsync(string id, SetBookRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
