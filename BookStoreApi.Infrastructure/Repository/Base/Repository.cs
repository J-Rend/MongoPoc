using BookStoreApi.Domain.Entities.Base;
using BookStoreApi.Infrastructure.Abstraction.Base;
using BookStoreApi.Infrastructure.Context.Base;
using MongoDB.Driver;

namespace TStoreApi.Infrastructure.Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> _collection;
        protected IContext _context { get; }

        public Repository(IContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            _context = context;
            _collection = _context.GetMongoCollection<T>();
        }

        public async Task<IEnumerable<T>> GetAsync(int? totalItems, CancellationToken cancellationToken) =>
            await _collection.Find(_ => true).Limit(totalItems).ToListAsync(cancellationToken);

        public async Task<T?> GetAsync(string id, CancellationToken cancellationToken) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

        public async Task CreateAsync(T newEntity, CancellationToken cancellationToken) =>
            await _collection.InsertOneAsync(newEntity, cancellationToken);

        public async Task UpdateAsync(string id, T updatedEntity, CancellationToken cancellationToken) =>
            await _collection.FindOneAndReplaceAsync(x => x.Id == id, updatedEntity, null, cancellationToken);

        public async Task RemoveAsync(string id, CancellationToken cancellationToken) =>
            await _collection.DeleteOneAsync(x => x.Id == id, cancellationToken);
    }
}
