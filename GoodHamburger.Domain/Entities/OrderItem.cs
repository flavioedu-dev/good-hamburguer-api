using GoodHamburger.Domain.Entities.Base;
using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProductCategory Category { get; set; }
    public int Quantity { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public decimal Subtotal => Price * Quantity;
}
