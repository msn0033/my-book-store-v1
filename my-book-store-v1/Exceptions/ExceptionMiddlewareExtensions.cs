using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using my_book_store_v1.Date.Dto;
using System.Net;

namespace my_book_store_v1.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {

                    context.Response.StatusCode = ((int)HttpStatusCode.InternalServerError);
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); //get error
                    var RequestFeature = context.Features.Get<IHttpRequestFeature>();//get request
                    if (contextFeature is not null)
                    {
                        await context.Response.WriteAsync(new ErrorDto
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Path=RequestFeature.Path

                        }.ToString()); 
                    }

                });
            });
        }
        public static void ConfigureCustomeExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomeExceptiomMiddleWare>();
            
        }
    }
}
