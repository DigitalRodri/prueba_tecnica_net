using Domain.Interfaces;
using Domain.Profiles;
using Domain.Services;
using Infraestructure.Repository;
using Infraestructure.Repository.Models;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

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
