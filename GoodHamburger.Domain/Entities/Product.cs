using GoodHamburger.Domain.Entities.Base;
using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public ProductCategory Category { get; set; }
}
