using my_book_store_v1.Data.Models;

namespace my_book_store_v1.Data.Dto
{
    public class BookDto
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string CoverUrl { get; set; }
        public string Genre { get; set; }

        public int PublisherId { get; set; }
        public List<int>  AuthorIds { get; set; }
    }
       
}
