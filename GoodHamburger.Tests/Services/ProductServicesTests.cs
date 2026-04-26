using GoodHamburger.Application.Interfaces;
using GoodHamburger.Application.Services;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enums;
using GoodHamburger.Domain.Interfaces.Repositories;

namespace GoodHamburger.Tests.Services;

[TestFixture]
public class ProductServicesTests
{
    private Mock<IProductRepository> _productRepositoryMock;
    private ProductServices _productServices;

    [SetUp]
    public void Setup()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _productServices = new ProductServices(_productRepositoryMock.Object);
    }

    [Test]
    public async Task GetAllAsync_WhenProductsExist_ReturnsAllProducts()
    {
        var products = new List<Product>
        {
            new() { Id = 1, Name = "Burger", Price = 10, Category = ProductCategory.Burger },
            new() { Id = 2, Name = "Fries", Price = 5, Category = ProductCategory.Side }
        };

        _productRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);

        var result = await _productServices.GetAllAsync();

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Name, Is.EqualTo("Burger"));
            Assert.That(result[1].Name, Is.EqualTo("Fries"));
        });
    }
}
