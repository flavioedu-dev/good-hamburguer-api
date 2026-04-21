using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories.Base;
using GoodHamburger.Infrastructure.Contexts;
using GoodHamburger.Infrastructure.Repositories.Base;

namespace GoodHamburger.Infrastructure.Repositories;

public class OrdemItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
{
    public OrdemItemRepository(SqlDbContext context) : base(context)
    {
    }
}
