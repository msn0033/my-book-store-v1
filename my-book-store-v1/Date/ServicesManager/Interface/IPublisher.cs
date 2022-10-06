using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.Paging;

namespace my_book_store_v1.Date.ServicesManager.Interface
{
    public interface IPublisher
    {

        Task<Publisher> AddPublisherAsync(PublisherDto publisherDto);
        Task<PagedList<Publisher>> GetPublishersAsync(string OrderBy,string searchValue, int? PageNumber, int? PageSize);
        Task<Publisher> GetPublisherByIdAsync(int id);
        Task<Publisher> GetPublisherByNameAsync(string name);
        Task<Publisher> UpdatePublisherAsync(int id,PublisherDto publisher);
        Task<Publisher> DeletePublisherAsync(int id);
        bool IsExistsAsync(int id);
        Task SaveAsync();


   

    }
}
