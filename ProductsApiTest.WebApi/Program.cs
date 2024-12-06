using Microsoft.EntityFrameworkCore;
using ProductsApiTest.WebApi.Application.Services;
using ProductsApiTest.WebApi.Domain.Contracts;
using ProductsApiTest.WebApi.Infrastructure;
using ProductsApiTest.WebApi.Infrastructure.EFCoreConfiguration;
using ProductsApiTest.WebApi.Infrastructure.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string server = builder.Configuration.GetValue<string>("SqlServerConnectionString:Server");
string database = builder.Configuration.GetValue<string>("SqlServerConnectionString:Database");
string user = builder.Configuration.GetValue<string>("SqlServerConnectionString:User");
string password = builder.Configuration.GetValue<string>("SqlServerConnectionString:Password");

string sqlServerConnecionString = DatabaseConnection.SetConnectionString(server, database, user, password);
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(sqlServerConnecionString);
});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();


builder.Services.AddTransient<IProduct, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
