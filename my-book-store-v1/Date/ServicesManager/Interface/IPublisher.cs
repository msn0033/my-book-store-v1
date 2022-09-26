using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;

namespace my_book_store_v1.Date.ServicesManager.Interface
{
    public interface IPublisher
    {

        Task<Publisher> AddPublisherAsync(PublisherDto publisherDto);
        Task<IEnumerable<Publisher>> GetPublishersAsync();
        Task<Publisher> GetPublisherByIdAsync(int id);
        Task<Publisher> GetPublisherByNameAsync(string name);
        Task<Publisher> UpdatePublisherAsync(int id,PublisherDto publisher);
        Task<Publisher> DeletePublisherAsync(int id);
        bool IsExistsAsync(int id);
        Task SaveAsync();


   

    }
}
