using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Infrastructure.Contexts;
using GoodHamburger.Infrastructure.Repositories.Base;

namespace GoodHamburger.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(SqlDbContext context) : base(context)
    {
    }
}
