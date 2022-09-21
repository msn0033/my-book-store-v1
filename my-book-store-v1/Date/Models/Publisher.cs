namespace my_book_store_v1.Date.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property
        public List<Book> Books { get; set; }
    }
}
