using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Interfaces.Repositories.Base;

namespace GoodHamburger.Domain.Interfaces.Repositories;

public interface IOrderItemRepository : IBaseRepository<OrderItem>
{
    void DeleteByOrderId(int orderId);
}
