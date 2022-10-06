using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book_store_v1.Date.Dto.Versioning.V2;

namespace my_book_store_v1.Controllers.V2
{
    [ApiVersion("2.0")]
    //[Route("api/V{version:apiversion}/[controller]")] //URL
    [Route("api/[controller]")]
    [ApiController]

    public class ReadersController : ControllerBase
    {
        public List<ReaderDto> _readers { get; set; } = new List<ReaderDto>
        {
            new ReaderDto{ Id=1,Name="jone",Address="USA",IsRead=false,BorrowDate=DateTime.Now.AddDays(-3),ReturnDate=DateTime.Now.AddDays(5)},
            new ReaderDto{ Id=2,Name="sami",Address="KSA",IsRead=true,BorrowDate=DateTime.Now.AddDays(-1),ReturnDate=DateTime.Now.AddDays(3)},
            new ReaderDto{ Id=3,Name="kream",Address="EGP",IsRead=false,BorrowDate=DateTime.Now.AddDays(-4),ReturnDate=DateTime.Now.AddDays(7)},
            new ReaderDto{ Id=4,Name="salah",Address="YEM",IsRead=false,BorrowDate=DateTime.Now.AddDays(-7),ReturnDate=DateTime.Now.AddDays(10)},
            new ReaderDto{ Id=5,Name="saeed",Address="QAT",IsRead= true,BorrowDate=DateTime.Now.AddDays(-5),ReturnDate=DateTime.Now.AddDays(-5)},
        };

        [HttpGet("get-All-reader")]
        public IActionResult GetAllReader()
        {
            return Ok(_readers);
        }


        [HttpGet("get-Reader-by-Id/{id}")]
        public IActionResult GetReaderById(int id)
        {
            return Ok(_readers[id]);
        }
    }
}
