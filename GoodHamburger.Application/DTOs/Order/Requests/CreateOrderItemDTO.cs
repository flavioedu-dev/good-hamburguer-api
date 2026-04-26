namespace GoodHamburger.Application.DTOs.Order.Requests;

public record CreateOrderItemDTO
(
    int ProductId,
    int Quantity
);
