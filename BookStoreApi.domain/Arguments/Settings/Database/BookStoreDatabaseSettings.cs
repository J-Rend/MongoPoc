namespace BookStoreApi.domain.Arguments.Settings.Database
{
    public class BookStoreDatabaseSettings
    {

        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string BooksCollectionName { get; set; } = null!;

    }
}
