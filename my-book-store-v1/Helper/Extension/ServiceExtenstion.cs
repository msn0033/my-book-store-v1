using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using my_book_store_v1.Controllers.V1;

namespace my_book_store_v1.Helper.Extension
{
    public static class ServiceExtenstion
    {
        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(op =>
            {
                op.ReportApiVersions = true;

                op.AssumeDefaultVersionWhenUnspecified = true;
                op.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(2, 0);

                op.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("X-Version"),//change query String
                    new HeaderApiVersionReader("Custom-Api-Version"), //Header reader
                    new MediaTypeApiVersionReader("Ver")
                    //new MediaTypeApiVersionReader()
                    );


                op.Conventions.Controller<ReadersController>()
                .HasApiVersion(1, 0)
                .HasApiVersion(3, 0)
                .HasDeprecatedApiVersion(1, 6);
            });
            
        }
    }
}
