using GoodHamburger.Application.DTOs.Orders;
using GoodHamburger.Application.DTOs.Orders.Requests;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enums;
using GoodHamburger.Domain.Exceptions;
using GoodHamburger.Domain.Interfaces.Repositories;
using Mapster;

namespace GoodHamburger.Application.Services;

public class OrderServices : IOrderServices
{
    private readonly IOrderRepository _orderRepository;
    public OrderServices(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderDTO>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();

        var orderResponseDTOList = orders.Adapt<List<OrderDTO>>();

        return orderResponseDTOList;
    }

    public async Task<OrderDTO> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id)
            ?? throw new CustomResponseException($"Pedido com Id {id} não encontrado.", 404);

        var orderResponseDTO = order.Adapt<OrderDTO>();

        return orderResponseDTO;
    }
}
