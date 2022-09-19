using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.Repository;

namespace my_book_store_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region ID
        private readonly  IRepository<Book> _BookService;
        public BooksController(IRepository<Book> repository)
        {
            _BookService = repository;
        }
        #endregion

        //Get: api/Books
        [HttpGet]
        public async Task<ActionResult< IEnumerable<Book>>> GetBooks() {
            return Ok( await _BookService.GetAllAsync());
        }

        //GET : api/Books/5
        [HttpGet("{id}")]
        public async Task <ActionResult<Book>>GetBook(int id)
        {
            var book= await _BookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);

        }

        //Post: api/Books
        [HttpPost]
        public async Task<ActionResult> AddBook(BookDto b)
        {
            Book book = new Book
            {
                CoverUrl = b.CoverUrl,
                Description = b.Description,
                Title = b.Title,
                Genre = b.Genre,
                IsRead = b.IsRead,
                DateRead = b.IsRead ? b.DateRead.Value: null,
                Rate = b.IsRead ? b.Rate.Value : null,
                DateAdded = DateTime.Now
            };
          
            await _BookService.AddAsync(book);
            await _BookService.SaveAsync();
            return Created("Ok", book);
        }

        //DELETE : api/Books/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var e= await _BookService.DeleteAsync(id);
            if (e == null) return NotFound();
            await _BookService.SaveAsync();
            return NoContent();    
        }

        //put :api/Books/8
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id,Book book)
        {
            if(id != book.Id)
                return BadRequest();

           var e= _BookService.Update(book);
            if(e==null)
            return NotFound();
          
            return NoContent();
        }

    }
}
