using GoodHamburger.Application.DTOs.Product;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Interfaces.Repositories;
using Mapster;

namespace GoodHamburger.Application.Services;

public class ProductServices : IProductServices
{
    private readonly IProductRepository _productRepository;

    public ProductServices(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDTO>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        var productDTOList = products.Adapt<List<ProductDTO>>();

        return productDTOList;
    }
}
