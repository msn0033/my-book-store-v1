using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Data;
using my_book_store_v1.Data.Dto;
using my_book_store_v1.Data.Models;
using my_book_store_v1.Data.ServicesManager.Interface;
using my_book_store_v1.Data.ServicesManager.Service;

using my_book_store_v1.Exceptions;
using my_book_store_v1.Helper.Extension;
using Serilog;

try
{

    #region Configure Serilog

    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();//read from appsettings.json
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger(); //Create logger
                                                                                          //throw new Exception("test exception from startup");   
    #endregion

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();

    #region DataBase
    //ConnectionString
    var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnectionStrings");
    // DataBase call
    builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(ConnectionString));
    #endregion

    builder.Services.AddTransient<IBook, BookService>();
    builder.Services.AddTransient<IAuthor, AuthorService>();
    builder.Services.AddTransient<IPublisher, PublisherService>();

    #region Versioning
    //7-47 Versioning
    //builder.Services.AddApiVersioning();

    //7-48 Versioning
    // Helper-Extension
    builder.Services.ConfigureVersioning();
    #endregion
    #region Caching
    builder.Services.AddResponseCaching();
    #endregion
    #region add profile caching
    builder.Services.AddControllers(configure =>
    configure.CacheProfiles.Add("100secondsDuration", new Microsoft.AspNetCore.Mvc.CacheProfile { Duration = 100 }));
    #endregion
    #region extension caching global
    builder.Services.ConfigureHttpCacheHeaders();
    #endregion
    #region Rate Limiting
    builder.Services.AddMemoryCache();
    builder.Services.ConfigureRateLimitingOptions();
    builder.Services.AddHttpContextAccessor();
    #endregion
    #region Cors

    builder.Services.AddCors(op =>
    {
        op.AddPolicy("AllowAll", option =>
        {
            option.AllowAnyHeader();
            option.AllowAnyMethod();
            option.AllowAnyOrigin();
        });
    });
    #endregion


    //============================ APP ================================================
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        //app.UseSwagger();
        //app.UseSwaggerUI();
    }
   

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    //app.ConfigureExceptionHandler(); //Exception Global
    app.ConfigureCustomeExceptionMiddleWare();//Exception Global
    app.UseResponseCaching();//define cache - Cashing
    app.UseHttpCacheHeaders();//supporting Validation - Caching
    app.UseIpRateLimiting();// Rate Limiting
    app.UseCors("AllowAll");//Cors
  
    await AppDbInitializer.SeedAsync(app);//Seeding data


    // Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));
    app.Run();
}


catch (Exception ex)
{
    Log.Fatal(ex.Message, "this is faild log :   ");

}
finally
{
    Log.CloseAndFlush();
}




