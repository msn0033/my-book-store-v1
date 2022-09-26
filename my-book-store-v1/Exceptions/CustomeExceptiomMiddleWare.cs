using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using my_book_store_v1.Date.Dto;
using System.Net;

namespace my_book_store_v1.Exceptions
{
    public class CustomeExceptiomMiddleWare
    {
        private readonly RequestDelegate _next;

        public CustomeExceptiomMiddleWare(RequestDelegate next)
        {

            this._next = next;
        }

        public async Task InvokeAsync(HttpContext content)
        {
            try
            {
                await _next(content);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(content, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext content, Exception ex)
        {
            content.Response.ContentType = "application/json";

            var contentRequest = content.Features.Get<IHttpRequestFeature>();
            var response = new ErrorDto
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = ex.Message + ex.InnerException + ex.StackTrace,
                Path = contentRequest.Path
            };
            return content.Response.WriteAsync(response.ToString());
        }
    }
}
