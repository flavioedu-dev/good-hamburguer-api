namespace GoodHamburger.Application.DTOs.Orders;

public record OrderDTO
(
    int Id,
    List<OrderItemDTO> OrderItems,
    decimal Discount,
    decimal Subtotal,
    decimal TotalPrice
);
