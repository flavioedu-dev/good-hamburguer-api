using FluentValidation;
using GoodHamburger.API.Extensions;
using GoodHamburger.API.Filters;
using GoodHamburger.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddValidatorsFromAssembly(typeof(Program).Assembly);
services.AddScoped<ValidationFilter>();
services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

services.AddDbContext<SqlDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("GoodHamburger.Infrastructure")
    )
);

services.AddApplicationDI();
services.AddInfrastructureDI();

services.AddSwaggerGen();

services.RegisterMappings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddMiddlewares();

app.Run();
