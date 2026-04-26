using GoodHamburger.Application.DTOs.Product;

namespace GoodHamburger.Application.Interfaces;

public interface IProductServices
{
    Task<List<ProductDTO>> GetAllAsync();
}
