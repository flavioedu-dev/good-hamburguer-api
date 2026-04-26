namespace GoodHamburger.Application.DTOs.Order.Requests;

public record UpdateOrderDTO
(
    List<CreateOrderItemDTO> OrderItems
);
