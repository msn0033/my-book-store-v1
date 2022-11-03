namespace my_book_store_v1.Data.Dto
{
    public class AuthorWithBooksDto
    {
        public string AuthorName { get; set; }
        public List<string> Books { get; set; }
    }
}
