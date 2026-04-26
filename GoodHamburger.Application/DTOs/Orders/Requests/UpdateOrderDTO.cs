namespace GoodHamburger.Application.DTOs.Orders.Requests;

public record UpdateOrderDTO
(
    List<CreateOrderItemDTO> OrderItems
);
