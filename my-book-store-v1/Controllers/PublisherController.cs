using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.ServicesManager.Interface;
using my_book_store_v1.Exceptions;
using Newtonsoft.Json;

namespace my_book_store_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        #region Di
        private readonly IPublisher _publisher;

        public PublisherController(IPublisher publisher)
        {
            this._publisher = publisher;
        }
        #endregion

        [HttpGet("get-all-Publisher")]
        public async Task<IActionResult> GetPublishers(string OrderBy, string search, int? PageNumber, int? PageSize)
        {
            try
            {
                var item = await _publisher.GetPublishersAsync(OrderBy, search,PageNumber,PageSize);
               
                if (item is null)
                    return NoContent();
              
                var metadata = new
                {
                    item.PageSize,
                    item.CurrrentPage,
                    item.TotalPages,
                    item.HasNext,
                    item.HasPrevious
                };
                Response.Headers.Add("pagenation", JsonConvert.SerializeObject(metadata));

                return Ok(item);
            }
            catch (Exception ex)
            {

                 return BadRequest($"can,t find any  publisher + {ex.Message}");
               
            }
        }
        [HttpPost("add-publisher")]
        public async Task<IActionResult> PostAddPublisher([FromBody] PublisherDto publisherDto)
        {
            var publisher = await _publisher.AddPublisherAsync(publisherDto);
            if (publisher == null) return BadRequest();
            return Created(nameof(PostAddPublisher), publisher);
        }

    }
}
