using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;


namespace my_book_store_v1.Helper.Extension
{
    public static class ServiceExtenstion
    {
        //Versioning
        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(op =>
            {
                op.ReportApiVersions = true;

                op.AssumeDefaultVersionWhenUnspecified = true;
                op.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(2, 0);//default 2.0

                op.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("X-Version"),//change query String
                    new HeaderApiVersionReader("Custom-Api-Version"), //Header reader
                    new MediaTypeApiVersionReader("Ver")
                    //new MediaTypeApiVersionReader()
                    );


                op.Conventions.Controller<Controllers.V1.ReadersController>()
                .HasApiVersion(1, 0)
                .HasApiVersion(3, 0)
                .HasDeprecatedApiVersion(1, 6);

                op.Conventions.Controller<Controllers.V2.ReadersController>()
                .HasApiVersion(2, 0);
                //.HasDeprecatedApiVersion(0.5);
            });
        }

        //Cache
        public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
        {
            services.AddHttpCacheHeaders(
                expirationOpt =>
                {
                    expirationOpt.MaxAge = 30;
                    expirationOpt.CacheLocation = Marvin.Cache.Headers.CacheLocation.Public;

                },
                validationOpt =>
                {
                    validationOpt.MustRevalidate = true;
                }
                );
        }

        //Rate Limitng
        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {

            var rateLimitrule = new List<RateLimitRule>()
            {
                new RateLimitRule
                {
                    Endpoint="*",
                    Limit=3,
                    Period="20s"
                },
                    new RateLimitRule
                {
                    Endpoint="mur",
                    Limit=20,
                    Period="20s"
                }
            };//end rateLimit

            services.Configure<IpRateLimitOptions>(op =>
            {
                op.GeneralRules = rateLimitrule;
            });
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

        }

    }
}
