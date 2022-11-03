using Microsoft.AspNetCore.Mvc;
using my_book_store_v1.Data.Dto;
using my_book_store_v1.Data.ServicesManager.Interface;

namespace my_book_store_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        #region DI Context
        private readonly IAuthor _author;
        private readonly ILogger <AuthorsController> _logger;

        public AuthorsController(IAuthor author, ILogger<AuthorsController> logger)
        {
            this._author = author;
            _logger = logger;
        }

        #endregion

        [HttpGet("Get-all-Author")]
       // [ResponseCache()]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
               // throw new NullReferenceException("serilogerrrrrrrrrrrrrrrrrrrrr");
                var item = await _author.GetAuthorsAsync();
                if (item is null)
                    return NotFound();
                return Ok(item);
            }
            catch (Exception )
            {

                throw ;
            }
       

        }
       
        [HttpGet("get-Author-with-books/{id}")]
       // [ResponseCache(CacheProfileName = "100secondsDuration")]
        public async  Task<IActionResult> GetAuthorWithBooksDto(int id)
        {
            var item =await _author.GetAuthorWithBooksDtoByIdAsync(id);
            if(item == null)return NotFound("لايوجد بيانات");
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
