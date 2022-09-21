using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetAuthorWithBooksDto(int id)
        {
            var item =_author.GetAuthorWithBooksDtoByIdAsync(id);
            if(item == null)return NotFound();
            return Ok(item);
        }
    }
}
