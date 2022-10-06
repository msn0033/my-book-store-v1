using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.Paging;
using my_book_store_v1.Date.ServicesManager.Interface;
using my_book_store_v1.Exceptions;
using System.Text.RegularExpressions;

namespace my_book_store_v1.Date.ServicesManager.Service
{
    public class PublisherService : IPublisher
    {
        #region DI
        private readonly AppDbContext _DbContext;
        public PublisherService(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        #endregion

        public async Task<Publisher> AddPublisherAsync(PublisherDto publisherDto)
        {
            if (PublisherStartWithletter(publisherDto.Name))
                throw new PublisherNameException("لا يجب ان يكون بداية الاسم  رقم ", publisherDto.Name);
            Publisher publisher = new Publisher { Name = publisherDto.Name };
            await _DbContext.Publishers.AddAsync(publisher);
            await SaveAsync();
            return publisher;
        }

        public Task<Publisher> DeletePublisherAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Publisher> GetPublisherByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Publisher> GetPublisherByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<Publisher>> GetPublishersAsync(string OrderBy,string searchValue,int? PageNumber,int? PageSize)
        {
            var publisherList = await _DbContext.Publishers.OrderBy(x => x.Id).ToListAsync();
           // throw new Exception("murad how are you");
            //Sorting
            if (string.IsNullOrEmpty(OrderBy))
            {
                switch (OrderBy)
                {
                    case "name_desc":
                        publisherList = publisherList.OrderBy(x => x.Name.ToLower()).ToList();
                        break;
                    case "id_desc":
                        publisherList = publisherList.OrderBy(x => x.Id).ToList();
                        break;
                    default:
                        break;

                }
            }
            //Filtring
            if(string.IsNullOrEmpty(searchValue))
            {
               
                publisherList=publisherList.Where(x=>x.Name.Contains(searchValue,StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            //paging
            publisherList = PagedList<Publisher>.ToPagedList(publisherList.AsQueryable(), PageNumber ?? 1, PageSize ?? 5);
            return (PagedList<Publisher>)publisherList ;
        }

        public bool IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _DbContext.SaveChangesAsync();
        }

        public Task<Publisher> UpdatePublisherAsync(int id, PublisherDto publisher)
        {
            throw new NotImplementedException();
        }

        private bool PublisherStartWithletter(string name) => Regex.IsMatch(name, @"^\d");
    }
}
