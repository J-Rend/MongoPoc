using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Domain.Entities.Base
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; protected set; }

        public List<(string Key, string Message)> Errors { get; private set; }

        public bool IsInvalid { get { return Errors.Any(); } }

        public void AddError(string Key, string Message)
        {
            Errors.Add((Key, Message));
        }

    }
}
