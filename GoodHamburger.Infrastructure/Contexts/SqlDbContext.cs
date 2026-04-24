using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.Contexts;

public class SqlDbContext : DbContext
{
    public DbSet<Product> Products { get; }
    public DbSet<OrderItem> OrderItems { get; }
    public DbSet<Order> Orders { get; }

    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "X Burger",
                Price = 5m,
                Description = "Pão, carne, queijo, alface, tomate e molho especial.",
                Category = ProductCategory.Burger,
                Active = true,
                CreatedAt = new DateTime(2024, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = null
            },
            new Product
            {
                Id = 2,
                Name = "X Egg",
                Price = 4.50m,
                Description = "Pão, carne, ovo, alface, tomate e maionese.",
                Category = ProductCategory.Burger,
                Active = true,
                CreatedAt = new DateTime(2024, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = null
            },
            new Product
            {
                Id = 3,
                Name = "X Bacon",
                Price = 7m,
                Description = "Pão integral, carne, bacon, alface e tomate.",
                Category = ProductCategory.Burger,
                Active = true,
                CreatedAt = new DateTime(2024, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = null
            },
            new Product
            {
                Id = 4,
                Name = "Batata Frita",
                Price = 2m,
                Description = "Porção de batatas fritas crocantes.",
                Category = ProductCategory.Side,
                Active = true,
                CreatedAt = new DateTime(2024, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = null
            },
            new Product
            {
                Id = 5,
                Name = "Refrigerante",
                Price = 2.50m,
                Description = "Lata de refrigerante gelado.",
                Category = ProductCategory.Drink,
                Active = true,
                CreatedAt = new DateTime(2024, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = null
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
