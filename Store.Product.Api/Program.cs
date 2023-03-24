using Microsoft.EntityFrameworkCore;
using Store.Product.Api.AutoMapper;
using Store.Product.Api.Entity.Context;
using Store.Product.Api.Repository;
using Store.Product.Api.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection String configuration
var connectionString = builder.Configuration["SQLServerConnection:SQLServerConnectionString"];
builder.Services.AddDbContext<ProductContext>(opt => opt.UseSqlServer(connectionString));

// AutoMapper configuration
var mapper = Configuration.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Dependency Injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
