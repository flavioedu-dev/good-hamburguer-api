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
    private readonly IProductRepository _productRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IDiscountServices _discountServices;
    public OrderServices(IOrderRepository orderRepository, IProductRepository productRepository, IOrderItemRepository orderItemRepository, IDiscountServices discountServices)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _orderItemRepository = orderItemRepository;
        _discountServices = discountServices;
    }

    public async Task<List<OrderDTO>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllWithOrderItemsAsync();

        var orderResponseDTOList = orders.Adapt<List<OrderDTO>>();

        return orderResponseDTOList;
    }

    public async Task<OrderDTO> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdWithOrderItemsAsync(id)
            ?? throw new CustomResponseException($"Pedido com Id {id} não encontrado.", 404);

        var orderResponseDTO = order.Adapt<OrderDTO>();

        return orderResponseDTO;
    }

    public async Task<OrderDTO> CreateAsync(CreateOrderDTO createOrderDTO)
     {
        List<OrderItem> orderItems = [];

        foreach (var orderItem in createOrderDTO.OrderItems)
        {
            var product = await _productRepository.GetByIdAsync(orderItem.ProductId)
                ?? throw new CustomResponseException($"Produto com Id {orderItem.ProductId} não encontrado.", 404);

            var newOrderItem = product.Adapt<OrderItem>();
            newOrderItem.Quantity = orderItem.Quantity;

            orderItems.Add(newOrderItem);
        }

        var newOrder = new Order { OrderItems = orderItems };

        newOrder.CalculateSubtotal();

        var limitPerCategoryExceeded = newOrder.OrderItems
            .GroupBy(item => item.Category);

        if(newOrder.OrderItems.Any(item => item.Quantity > 1) || limitPerCategoryExceeded.Any(group => group.Count() > 1))
            throw new CustomResponseException($"O pedido pode conter apenas um produto de cada categoria.", 400);

        newOrder.Discount = _discountServices.CalculateDiscount(newOrder);

        newOrder.CalculateTotalPrice();

        await _orderRepository.CreateAsync(newOrder);
        await _orderRepository.SaveAsync();

        var orderCreatedDTO = newOrder.Adapt<OrderDTO>();
        return orderCreatedDTO;
    }

    public async Task UpdateAsync(int id, UpdateOrderDTO updateOrderDTO)
    {
        var order = await _orderRepository.GetByIdAsync(id)
            ?? throw new CustomResponseException($"Pedido com Id {id} não encontrado.", 404);

        order.OrderItems.Clear();
        _orderItemRepository.DeleteByOrderId(order.Id);

        List<OrderItem> updatedOrderItems = [];

        foreach (var orderItemDto in updateOrderDTO.OrderItems)
        {
            var product = await _productRepository.GetByIdAsync(orderItemDto.ProductId)
                ?? throw new CustomResponseException($"Produto com Id {orderItemDto.ProductId} não encontrado.", 404);

            var updatedOrderItem = product.Adapt<OrderItem>();
            updatedOrderItem.Quantity = orderItemDto.Quantity;

            updatedOrderItems.Add(updatedOrderItem);
        }

        order.OrderItems = updatedOrderItems;

        var limitPerCategoryExceeded = order.OrderItems.GroupBy(item => item.Category);

        if (order.OrderItems.Any(item => item.Quantity > 1) || limitPerCategoryExceeded.Any(group => group.Count() > 1))
            throw new CustomResponseException($"O pedido pode conter apenas um produto de cada categoria.", 400);

        order.CalculateSubtotal();
        order.Discount = _discountServices.CalculateDiscount(order);
        order.CalculateTotalPrice();

        await _orderRepository.UpdateAsync(order);
        await _orderRepository.SaveAsync();
    }
}
