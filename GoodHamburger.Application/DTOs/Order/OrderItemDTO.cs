using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Application.DTOs.Order;

public record OrderItemDTO
(
    int Id,
    int ProductId,
    string Name,
    decimal Price,     
    ProductCategory Category,
    int Quantity,
    decimal Subtotal
);