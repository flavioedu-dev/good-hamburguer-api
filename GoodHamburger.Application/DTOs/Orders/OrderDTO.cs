namespace GoodHamburger.Application.DTOs.Orders;

public record OrderDTO
(
    int Id,
    ICollection<OrderItemDTO> OrderItems,
    decimal Discount,
    decimal Subtotal,
    decimal TotalPrice
);
