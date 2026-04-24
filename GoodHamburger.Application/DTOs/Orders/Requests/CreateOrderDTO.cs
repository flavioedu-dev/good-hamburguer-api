namespace GoodHamburger.Application.DTOs.Orders.Requests;

public record CreateOrderDTO
(
    List<CreateOrderItemDTO> OrderItems
);
