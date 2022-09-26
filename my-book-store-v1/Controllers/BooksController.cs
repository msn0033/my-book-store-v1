using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.ServicesManager.Interface;

namespace my_book_store_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region ID
        private readonly IBook _book;
        public BooksController(IBook book)
        {
            this._book = book;
        }
        #endregion

        //Get: api/Books
        [HttpGet("get-all-books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var items = await _book.GetBooksAsync();
            if (items == null) return NotFound() ;
            return Ok(items);
        }

        //GET : api/Books/5
        [HttpGet("get-book-by-Id/{id}")]
        public async Task <ActionResult<Book>>GetBook(int id)
        {
            var book= await _book.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);

        }

        //Post: api/Books
        [HttpPost("add-book")]
        public async Task<ActionResult> AddBook([FromBody]BookDto b)
        {

            var item=await _book.AddBookAsync(b);
            if (item == null)
                return BadRequest("خطاء لم تتم الاضافة");
            return Ok("تم الاضافة بنجاح");
        }

        //DELETE : api/Books/3
        [HttpDelete("delete-book-by-Id/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var item = await _book.DeleteBookAsync(id);
            if (item == null) return NotFound();
            await _book.SaveAsync();
            return Ok(item);
        }

        //put :api/Books/8
        [HttpPut("Update-book/{id}")]
        public async Task<ActionResult> UpdateBook(int id,BookDto book)
        {


            var item =await _book.UpdateBookAsync(book, id);
            if(item==null)
            return NotFound();
            await _book.SaveAsync();
            return Ok(item);
        }

    }
}
