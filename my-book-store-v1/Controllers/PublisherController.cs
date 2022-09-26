using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.ServicesManager.Interface;
using my_book_store_v1.Exceptions;

namespace my_book_store_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        #region Fi
        private readonly IPublisher _publisher;

        public PublisherController(IPublisher publisher)
        {
            this._publisher = publisher;
        }
        #endregion

        [HttpGet("get-all-Publisher")]
        public async Task<IActionResult>GetPublishers()
        {
            var item=await _publisher.GetPublishersAsync();
            if (item is null)
                return NoContent();
            return Ok(item);
        }
        [HttpPost("add-publisher")]
        public async Task<IActionResult> PostAddPublisher([FromBody]PublisherDto publisherDto)
        {
                var publisher = await _publisher.AddPublisherAsync(publisherDto);
                if (publisher == null) return BadRequest();
                return Created(nameof(PostAddPublisher), publisher);         
        }

    }
}
