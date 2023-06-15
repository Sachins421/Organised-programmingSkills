using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
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


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter username and password.",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        //BearerFormat = "JWT",
        Scheme = "basic"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="basic"
                }
            },
            new string[]{}
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicAuth v1"));
}

app.UseHttpsRedirection();

app.UseMiddleware<BasicAuthentication>();

app.UseAuthorization();

app.MapControllers();

app.Run();
