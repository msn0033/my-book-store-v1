namespace my_book_store_v1.Date.Paging
{
    public class PagedList<T> :List<T>
    {
        public int PageSize { get; set; }
        public int CurrrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext  =>CurrrentPage< TotalPages;
        public bool HasPrevious => CurrrentPage > 1;
        public PagedList(List<T> items,int PageNumber,int count,int pagesize)
        {
            CurrrentPage = PageNumber;
            PageSize = pagesize;
            TotalPages = ((int)Math.Ceiling(count / (double)pagesize));
            this.AddRange(items);
        }
        public static PagedList<T> ToPagedList(IQueryable<T>source,int PageNumber,int pageSize)
        {
            var count = source.Count();
            var items=source.Skip((PageNumber-1)*pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, PageNumber, count, pageSize);
        }
    }
}
