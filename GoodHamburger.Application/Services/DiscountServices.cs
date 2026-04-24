using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Application.Services;

public class DiscountServices : IDiscountServices
{
    public decimal CalculateDiscount(Order order)
    {
        var orderItems = order.OrderItems;
        var allCategories = Enum.GetValues<ProductCategory>();

        var rules = new (Func<bool> Condition, decimal Discount)[]
        {
        (
            () => allCategories.All(category => orderItems.Any(item => item.Category == category)),
            0.2m
        ),
        (
            () => orderItems.Any(item => item.Category == ProductCategory.Burger)
                && orderItems.Any(item => item.Category == ProductCategory.Drink),
            0.15m
        ),
        (
            () => orderItems.Any(item => item.Category == ProductCategory.Burger)
                && orderItems.Any(item => item.Category == ProductCategory.Side),
            0.1m
        )
        };

        var discount = rules.FirstOrDefault(rule => rule.Condition()).Discount;
        return Math.Round(order.Subtotal * discount, 2 , MidpointRounding.AwayFromZero);
    }
}
