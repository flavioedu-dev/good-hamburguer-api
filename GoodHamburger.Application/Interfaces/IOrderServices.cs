using GoodHamburger.Application.DTOs.Orders;
using GoodHamburger.Application.DTOs.Orders.Requests;

namespace GoodHamburger.Application.Interfaces;

public interface IOrderServices
{
    Task<List<OrderDTO>> GetAllAsync();
    Task<OrderDTO> GetByIdAsync(int id);
    Task<OrderDTO> CreateAsync(CreateOrderDTO createOrderDTO);
    Task UpdateAsync(int id, UpdateOrderDTO updateOrderDTO);
    Task DeleteAsync(int id);
}
