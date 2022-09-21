﻿namespace my_book_store_v1.Date.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }

        //Naviation property
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        //Naviation property
        public List<Book_Author> Book_Authors { get; set; }
    }
}
