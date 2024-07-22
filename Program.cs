using Microsoft.EntityFrameworkCore;
using WbApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));



// Add services to the container.

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Access-Control-Allow-Origin");

app.Use(async (ctx, next) =>
{
    await next();
    if (ctx.Response.StatusCode == 204)
    {
        ctx.Response.ContentLength = 0;
    }

});
app.UseCors(options =>
options.WithOrigins("http://localhost:example")
  .AllowAnyMethod()
  .AllowAnyHeader());

app.UseAuthorization();
app.UseCors("Access -Control-Allow-Origin");

app.MapControllers();

app.Run();
