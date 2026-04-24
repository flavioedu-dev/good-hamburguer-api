using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Application.Interfaces;

public interface IDiscountServices
{
    decimal CalculateDiscount(Order order);
}
