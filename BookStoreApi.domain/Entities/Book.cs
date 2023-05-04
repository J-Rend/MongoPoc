using BookStoreApi.Domain.Arguments.Request;
using BookStoreApi.Domain.Entities.Base;
using MongoDB.Bson;
using System.Diagnostics;
using System.Xml.Linq;

namespace BookStoreApi.Domain.Entities
{
    public class Book : Entity
    {
        public Book(string name, decimal price, string category, string author)
        {
            Id = new BsonObjectId(ObjectId.GenerateNewId()).ToString();
            Name = name;
            Price = price;
            Category = category;
            Author = author;
        }

        public Book(SetBookRequest request, string? id)
        {
            if (request.Name == "")
                AddError("InvalidName", "The name can't be empty.");

            if(request.Price <= decimal.Zero)
                AddError("InvalidPrice", "No book can have a value less than or equal to zero.");
            Id = id ?? new BsonObjectId(ObjectId.GenerateNewId()).ToString();
            Name = request.Name;
            Price = request.Price;
            Category = request.Category;
            Author = request.Author;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; } 

        public string Category { get; private set; }

        public string Author { get; private set; }

    }
}
