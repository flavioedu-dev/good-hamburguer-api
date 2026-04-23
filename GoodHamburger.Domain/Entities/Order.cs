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
        Subtotal = OrderItems.Sum(oi => oi.Subtotal);
    }

    public void CalculateTotalPrice()
    {
        CalculateSubtotal();
        TotalPrice = Subtotal - Discount;
    }
}
