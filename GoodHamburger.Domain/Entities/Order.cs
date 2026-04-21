using GoodHamburger.Domain.Entities.Base;

namespace GoodHamburger.Domain.Entities;

public class Order : BaseEntity
{
    public ICollection<OrderItem> OrderItems { get; set; } = [];
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
