using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Infrastructure.Contexts;
using GoodHamburger.Infrastructure.Repositories.Base;

namespace GoodHamburger.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(SqlDbContext context) : base(context)
    {
    }
}
