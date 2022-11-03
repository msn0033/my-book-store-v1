using Newtonsoft.Json;

namespace my_book_store_v1.Data.Dto
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
