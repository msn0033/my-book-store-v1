using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using my_book_store_v1.Data.Dto;
using Serilog;
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

        public async Task InvokeAsync(HttpContext content,ILoggerFactory loggerFactory)
        {
            try
            {
                await _next(content);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(content, ex,loggerFactory);
              
            }
        }
        private Task HandleExceptionAsync(HttpContext content, Exception ex,ILoggerFactory loggerFactory)
        {
            content.Response.ContentType = "application/json";
            var logger=loggerFactory.CreateLogger(nameof(HandleExceptionAsync));

            var contentRequest = content.Features.Get<IHttpRequestFeature>();
            var ErrorDtoString = new ErrorDto
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = ex.Message ,
                Path = contentRequest.Path
            }.ToString();
            logger.LogError(ErrorDtoString);
            return content.Response.WriteAsync(ErrorDtoString);
        }
    }
}
