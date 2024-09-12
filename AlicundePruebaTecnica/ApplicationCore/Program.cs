using Domain.Interfaces;
using Domain.Profiles;
using Domain.Services;
using Infraestructure.Repository;
using Infraestructure.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Get current environment appsettings.json file
string environment = builder.Environment.EnvironmentName;
var Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .Build();

// Add services to the containers
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration with XML file
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Alicunde Technical Test API",
        Description = "An ASP.NET Core Web API for Alicunde's technical test",
        Contact = new OpenApiContact
        {
            Name = "Rodrigo Escribano Cifuentes",
            Url = new Uri("https://github.com/DigitalRodri")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// HttpClient to be used in any part of the code
builder.Services.AddHttpClient();

// DB Connection String easily changed from Program.cs instead of each Context
builder.Services.AddDbContext<MarketPartiesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MarketPartiesConnectionString")));
builder.Services.AddScoped<MarketPartiesContext>();

// Dependency injection
builder.Services.AddScoped<IMarketPartiesService, MarketPartiesService>();
builder.Services.AddScoped<IMarketPartiesRepository, MarketPartiesRepository>();
builder.Services.AddAutoMapper(typeof(RetailerProfile));

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

app.Run();
