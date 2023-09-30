using Data.DatabaseSetting;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Extensions.DependencyInjection;
using Model.Data.DatabaseSettings;
using System.Text.Json.Serialization;
using MediatR;
using Data.DatabaseSettings;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionsettings = new DBSettings();
builder.Configuration.GetSection("MongoDatabase").Bind(connectionsettings);
builder.Services.AddSingleton<DBSettings>(connectionsettings);
builder.Services.ConfigurMongoDB();
//builder.Services.AddMediatR(sr => sr.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddMediatR(sr => sr.RegisterServicesFromAssembly(Service.AssembelyIdentity.Assembly));
builder.Services.AddMediatR(sr => sr.RegisterServicesFromAssembly(WebAPI.AssemblyIdentity.Assembly));
builder.Services.AddMediatR(sr => sr.RegisterServicesFromAssemblies(Domain.Mapping.Dto.AssemblyIdentity.Assembly));

//var domainAssemblies = new[] { Service.AssembelyIdentity.Assembly, WebAPI.AssemblyIdentity.Assembly, Domain.Mapping.Dto.AssemblyIdentity.Assembly };
//builder.Services.AddMediatR(domainAssemblies);
//services.AddMediatR(domainAssemblies);



/*builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection((nameof(DatabaseSettings))));
builder.Services.AddSingleton<DatabaseSettings>(s => s.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => 
        new MongoClient(builder.Configuration.GetValue<string>(Environment.GetEnvironmentVariable("DataBaseSettings:ConnectionSettings"))));*/

//builder.Services.AddScoped<IProductionLineRepository,ProductionLineRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Glass Order API", Version = "1.0" });
    c.CustomSchemaIds(x => x.Namespace + "_" + x.FullName); // Resolve if there is any conflict in schemaid generation, for example Basedata and SourceInformation etc. in Swagger documentation generation
});


builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
