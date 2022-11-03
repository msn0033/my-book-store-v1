using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book_store_v1.Data.Dto.Versioning.V1;

namespace my_book_store_v1.Controllers.V1
{
    //[ApiVersion("1.0")]
    //[ApiVersion("3.0")]
    [Route("api/[controller]")]
   // [Route("api/V{version:apiversion}/[controller]")] //URL
    [ApiController]
    public class ReadersController : ControllerBase
    {
        public List<ReaderDto> _readers { get; set; } = new List<ReaderDto>
        {
            new ReaderDto{ Id=1,Name="jone",Address="USA",IsRead=false},
            new ReaderDto{ Id=2,Name="sami",Address="KSA",IsRead=true},
            new ReaderDto{ Id=3,Name="kream",Address="EGP",IsRead=false},
            new ReaderDto{ Id=4,Name="salah",Address="YEM",IsRead=false},
            new ReaderDto{ Id=5,Name="saeed",Address="QAT",IsRead= true},
        };

        [HttpGet("get-All-reader")]
        public IActionResult GetAllReader()
        {
            return Ok(_readers);
        }

        [HttpGet("get-Reader-by-Id/{id}")]
        public IActionResult GetReadersById(int id)
        {
            return Ok(_readers[id]);
        }
    }
}
