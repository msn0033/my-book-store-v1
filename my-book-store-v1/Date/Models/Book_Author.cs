namespace my_book_store_v1.Date.Models
{
    public class Book_Author
    {
        //public int Id{ get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        //NavigationProperty
        public Book Book { get; set; }
        public Author Author { get; set; }

        public DateTime AddedOn { get; set; }

    }
}
