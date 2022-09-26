using Microsoft.AspNetCore.Mvc;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.ServicesManager.Interface;

namespace my_book_store_v1.Controllers
{
    public class AuthorsController : ControllerBase
    {
        #region DI Context
        private readonly IAuthor _author;

        public AuthorsController(IAuthor author)
        {
            this._author = author;
        }

        #endregion

        [HttpGet("Get-all-Author")]
        public async Task<IActionResult> GetAuthors()
        {
            var item = await _author.GetAuthorsAsync();
            if (item is null)
                return NotFound();
            return Ok(item);
        }

        [HttpGet("get-Author-with-books{id}")]
        public async  Task<IActionResult> GetAuthorWithBooksDto(int id)
        {
            var item =await _author.GetAuthorWithBooksDtoByIdAsync(id);
            if(item == null)return NotFound();
            return Ok(item);
        }

        [HttpPost("add-author")]
        public async Task<IActionResult> AddAuthor(AuthorDto authorDto)
        {
            var author =await _author.AddAuthorAsync(authorDto);
            if (author == null) return BadRequest();
            await _author.SaveAsync();
            return Created(nameof(AddAuthor), author);
        }
    }
}
