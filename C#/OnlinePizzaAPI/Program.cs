using Microsoft.Extensions.Options;
using OnlinePizzaAPI.Middleware;
using OnlinePizzaAPI.Models;
using OnlinePizzaAPI.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PizzaStoreDatabaseSettings>(builder.Configuration.GetSection("PizzaStoreDatabase"));

builder.Services.AddSingleton<PizzaServices>();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(Options => Options.JsonSerializerOptions.PropertyNamingPolicy = null);
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

app.UseMiddleware<BasicAuthentication>();

app.UseAuthorization();

app.MapControllers();

app.Run();
