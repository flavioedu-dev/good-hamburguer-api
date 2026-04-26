using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Application.DTOs.Product;

public record ProductDTO 
(
    int Id,
    string Name,
    decimal Price,
    string Description,
    ProductCategory Category
);
