namespace GoodHamburger.Application.DTOs.Order.Requests;

public record CreateOrderDTO
(
    List<CreateOrderItemDTO> OrderItems
);
