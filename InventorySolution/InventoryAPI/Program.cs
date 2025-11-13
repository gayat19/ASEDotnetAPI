using InventoryAPI.Contexts;
using InventoryAPI.Interfaces;
using InventoryAPI.Models;
using InventoryAPI.Repositories;
using InventoryAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
         {
             {
                   new OpenApiSecurityScheme
                     {
                         Reference = new OpenApiReference
                         {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                         }
                     },
                     new string[] {}
             }
         });
});

builder.Services.AddDbContext<InventoryContext>(opts =>
{
    opts.UseSqlite("Data Source=app.db");
});

builder.Services.AddAutoMapper(typeof(Product));

builder.Services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer=false,
                    ValidateAudience=false,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey= new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Keys:JwtKey"]??""))

                };
            });

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
builder.Services.AddScoped<ITokenService,TokenService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
