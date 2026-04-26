using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Infrastructure.Contexts;
using GoodHamburger.Infrastructure.Repositories.Base;

namespace GoodHamburger.Infrastructure.Repositories;

public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(SqlDbContext context) : base(context)
    {
    }

    public void DeleteByOrderId(int orderId)
    {
        var items = _context.OrderItems.Where(oi => oi.OrderId == orderId);
        _context.OrderItems.RemoveRange(items);
    }
}
