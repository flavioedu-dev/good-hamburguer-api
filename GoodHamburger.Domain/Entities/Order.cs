using GoodHamburger.Domain.Entities.Base;

namespace GoodHamburger.Domain.Entities;

public class Order : BaseEntity
{
    public List<OrderItem> OrderItems { get; set; } = [];
    public decimal Discount { get; set; }
    public decimal Subtotal { get; private set; }
    public decimal TotalPrice { get; private set; }

    public void CalculateSubtotal()
    {
        OrderItems.ForEach(oi => oi.CalculateSubtotal());
        Subtotal = Math.Round(OrderItems.Sum(oi => oi.Subtotal), 2, MidpointRounding.AwayFromZero);
    }

    public void CalculateTotalPrice()
    {
        CalculateSubtotal();
        TotalPrice = Math.Round(Subtotal - Discount, 2, MidpointRounding.AwayFromZero);
    }
}
