namespace GoodHamburger.Application.DTOs.Orders.Requests;

public record CreateOrderItemDTO
(
    int ProductId,
    int Quantity
);
