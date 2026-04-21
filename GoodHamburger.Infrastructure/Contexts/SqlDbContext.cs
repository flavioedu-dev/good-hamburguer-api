using GoodHamburger.Domain.Entities;
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
        base.OnModelCreating(modelBuilder);
    }
}
