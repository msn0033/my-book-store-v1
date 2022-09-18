﻿namespace my_book_store_v1.Date.Dto
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
    }
       
}
