namespace my_book_store_v1.Date.Models
{
    public class Book_Author
    {
        //public int Id{ get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        //NavigationProperty
        public Book Books { get; set; }
        public Author Authors { get; set; }
        public DateTime AddedOn { get; set; }

    }
}
