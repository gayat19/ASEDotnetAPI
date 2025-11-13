using InventoryAPI.Contexts;
using InventoryAPI.Interfaces;
using InventoryAPI.Models;
using InventoryAPI.Repositories;
using InventoryAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryContext>(opts =>
{
    opts.UseSqlite("Data Source=app.db");
});

builder.Services.AddAutoMapper(typeof(Product));
#region Logging
builder.Logging.AddLog4Net();
#endregion

#region Repositories
builder.Services.AddScoped<IRepository<int, Product>,ProductRepository>();
builder.Services.AddScoped<IRepository<string,User>,UserRepository>();
#endregion

#region Services
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IUserService,UserService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
