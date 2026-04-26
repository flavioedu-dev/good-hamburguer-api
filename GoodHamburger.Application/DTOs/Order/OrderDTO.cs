namespace GoodHamburger.Application.DTOs.Order;

public record OrderDTO
(
    int Id,
    List<OrderItemDTO> OrderItems,
    decimal Discount,
    decimal Subtotal,
    decimal TotalPrice
);
