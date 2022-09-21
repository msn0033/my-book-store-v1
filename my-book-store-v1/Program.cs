using Microsoft.EntityFrameworkCore;
using my_book_store_v1.Date;
using my_book_store_v1.Date.Dto;
using my_book_store_v1.Date.Models;
using my_book_store_v1.Date.ServicesManager.Interface;
using my_book_store_v1.Date.ServicesManager.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ConnectionString
var ConnectionString =builder.Configuration.GetConnectionString("DefaultConnectionStrings");
// DataBase call
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(ConnectionString));

builder.Services.AddTransient<IBook,BookService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//await AppDbInitializer.SeedAsync(app);

app.Run();


