using Data.DatabaseSetting;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Model.Data.DatabaseSettings;
using Service.Repositries;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionsettings = new DBSettings();
builder.Configuration.GetSection("MongoDatabase").Bind(connectionsettings);
builder.Services.ConfigurMongoDB();
builder.Services.AddMediatR(sr => sr.RegisterServicesFromAssembly(typeof(Program).Assembly));


/*builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection((nameof(DatabaseSettings))));
builder.Services.AddSingleton<DatabaseSettings>(s => s.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => 
        new MongoClient(builder.Configuration.GetValue<string>(Environment.GetEnvironmentVariable("DataBaseSettings:ConnectionSettings"))));*/

//builder.Services.AddScoped<IProductionLineRepository,ProductionLineRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
