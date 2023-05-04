using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json;

namespace BookStoreApi.Domain.Entities.Base
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; protected set; }

        [BsonIgnore]
        public List<(string Key, string Message)> Errors { get; private set; } = new List<(string Key, string Message)> ();

        [BsonIgnore]
        public bool IsInvalid { get { return Errors.Any(); } }

        [BsonIgnore]
        public string ErrorMessage { get
            {
                return JsonSerializer.Serialize(Errors);
            } 
        }

        public void AddError(string Key, string Message)
        {
            Errors.Add((Key, Message));
        }

    }
}
