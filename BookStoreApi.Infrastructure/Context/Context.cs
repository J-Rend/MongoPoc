using BookStoreApi.domain.Arguments.Settings.Database;
using BookStoreApi.Domain.Entities;
using BookStoreApi.Domain.Entities.Base;
using BookStoreApi.Infrastructure.Context.Base;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Infrastructure.Context
{
    public class Context : IContext
    {
        private Dictionary<string, Type> keyValuePairs = new Dictionary<string, Type>();

        private MongoClient mongoClient;
        private IMongoDatabase mongoDatabase;

        public Context(
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);
            mongoDatabase = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);
            mountKeyValuePairs();
        }

        public IMongoCollection<T> GetMongoCollection<T>() where T : Entity
        {
            var collectionName = RetrieveCollectionNameByType(typeof(T));
            var collection = mongoDatabase.GetCollection<T>(collectionName);

            return collection;
        }

        private string RetrieveCollectionNameByType(Type type)
        {
            return keyValuePairs
                .Where(w => w.Value.Equals(type))
                .FirstOrDefault()
                .Key;
        }

        private void mountKeyValuePairs()
        {
            keyValuePairs.Add("Books", typeof(Book));
        }

    }
}
