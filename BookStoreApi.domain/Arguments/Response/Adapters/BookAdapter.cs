using BookStoreApi.Domain.Entities;

namespace BookStoreApi.Domain.Arguments.Response.Adapters
{
    public static class BookAdapter
    {

        public static IEnumerable<GetBookResponse> AdaptToResponse(this IEnumerable<Book>? books)
        {
            if(books == null)
                return Enumerable.Empty<GetBookResponse>();

            return books.Select(s => new GetBookResponse
            {
                Author = s.Author,
                Category = s.Category,
                Name = s.Name,
                Price = s.Price
            });
        }

        public static GetBookResponse AdaptToResponse(this Book books)
        {
            return new GetBookResponse
            {
                Author = books.Author,
                Category = books.Category,
                Name = books.Name,
                Price = books.Price
            };
        }
    }
}
