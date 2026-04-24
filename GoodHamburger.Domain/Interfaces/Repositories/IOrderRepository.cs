using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories.Base;

namespace GoodHamburger.Domain.Interfaces.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<List<Order>> GetAllWithOrderItemsAsync();
    Task<Order?> GetByIdWithOrderItemsAsync(int id);
}
