namespace GoodHamburger.Application.DTOs.Orders.Requests;

public record CreateOrderDTO
(
    int ProductId, 
    int Quantity
);