using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Infrastructure.Contexts;
using GoodHamburger.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(SqlDbContext context) : base(context)
    {
    }

    public async Task<List<Order>> GetAllWithOrderItemsAsync()
    {
        return await _context.Orders
            .Include(order => order.OrderItems)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdWithOrderItemsAsync(int id)
    {
        return await _context.Orders
            .Include(order => order.OrderItems)
            .FirstOrDefaultAsync(order => order.Id == id);
    }
}
