using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
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
            if (PublisherStartWithCaptialletter(publisherDto.Name))
                throw new PublisherNameException("يجب ان يكون رقم صحيح",publisherDto.Name);
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

        public async Task<IEnumerable<Publisher>> GetPublishersAsync() => await _DbContext.Publishers.ToListAsync();


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

        private bool PublisherStartWithCaptialletter(string name) => Regex.IsMatch(name, @"^\d");
    }
}
