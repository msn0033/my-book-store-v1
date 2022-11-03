namespace my_book_store_v1.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //Naviation property
        public List<Book_Author>? Book_Authors { get; set; }
    }
}
