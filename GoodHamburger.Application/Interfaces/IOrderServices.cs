using GoodHamburger.Application.DTOs.Orders;

namespace GoodHamburger.Application.Interfaces;

public interface IOrderServices
{
    Task<List<OrderDTO>> GetAllAsync();
    Task<OrderDTO> GetByIdAsync(int id);
}
