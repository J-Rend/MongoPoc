using BookStoreApi.Domain.Abstractions.Application;
using BookStoreApi.Domain.Arguments.Request;
using BookStoreApi.Domain.Arguments.Response;
using BookStoreApi.Domain.Entities;
using BookStoreApi.Infrastructure.Abstraction;
using BookStoreApi.Domain.Arguments.Response.Adapters;
using BookStoreApi.Infrastructure.UnitOfWork;

namespace BookStoreApi.Application
{
    public class BookApplication : IBookApplication
    {
        private IUnitOfWork _unitOfWork;

        public BookApplication(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<string?> CreateBookAsync(SetBookRequest request, CancellationToken cancellationToken)
        {
            var entity = new Book(request, null);

            if (entity.IsInvalid)
                throw new InvalidCastException(entity.ErrorMessage);

            await _unitOfWork.Books.CreateAsync(entity, cancellationToken);

            return entity.Id;

        }

        public async Task DeleteBookAsync(string id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Books.GetAsync(id, cancellationToken);

            if(entity == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            await _unitOfWork.Books.RemoveAsync(id, cancellationToken);

        }

        public async Task<IEnumerable<GetBookResponse>> GetAllAsync(int? limit = 150, CancellationToken cancellationToken = default)
        {
            var response = await _unitOfWork.Books.GetAsync(limit, cancellationToken);

            return response.AdaptToResponse();
        }

        public async Task<GetBookResponse?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Books.GetAsync(id, cancellationToken);

            return response != null ? response.AdaptToResponse() : null;
        }

        public async Task UpdateBookAsync(string id, SetBookRequest request, CancellationToken cancellationToken)
        {
            var entity = new Book(request, id);

            if(entity.IsInvalid)
            {
                throw new InvalidCastException(entity.ErrorMessage);
            }

            await _unitOfWork.Books.UpdateAsync(id, entity, cancellationToken);
        }
    }
}
