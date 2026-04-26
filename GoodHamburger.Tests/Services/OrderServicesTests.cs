using GoodHamburger.Application.DTOs.Order.Requests;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Application.Services;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enums;
using GoodHamburger.Domain.Exceptions;
using GoodHamburger.Domain.Interfaces.Repositories;

namespace GoodHamburger.Tests.Services;

[TestFixture]
public class OrderServicesTests
{
    private Mock<IOrderRepository> _orderRepositoryMock;
    private Mock<IProductRepository> _productRepositoryMock;
    private Mock<IOrderItemRepository> _orderItemRepositoryMock;
    private Mock<IDiscountServices> _discountServicesMock;
    private OrderServices _orderServices;

    [SetUp]
    public void Setup()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _productRepositoryMock = new Mock<IProductRepository>();
        _orderItemRepositoryMock = new Mock<IOrderItemRepository>();
        _discountServicesMock = new Mock<IDiscountServices>();
        _orderServices = new OrderServices(
            _orderRepositoryMock.Object,
            _productRepositoryMock.Object,
            _orderItemRepositoryMock.Object,
            _discountServicesMock.Object
        );
    }

    [Test]
    public void GetByIdAsync_WhenOrderDoesNotExist_ThrowsCustomResponseException()
    {
        _orderRepositoryMock.Setup(x => x.GetByIdWithOrderItemsAsync(It.IsAny<int>())).ReturnsAsync((Order)null!);

        Assert.ThrowsAsync<CustomResponseException>(async () => await _orderServices.GetByIdAsync(1));
    }

    [Test]
    public void CreateAsync_ShouldThrow_WhenProductDoesNotExist()
    {
        var createOrderDTO = new CreateOrderDTO(new List<CreateOrderItemDTO> { new(1, 1) });

        _productRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null!);

        Assert.ThrowsAsync<CustomResponseException>(async () => await _orderServices.CreateAsync(createOrderDTO));
    }

    [Test]
    public void CreateAsync_ShouldThrow_WhenMoreThanOneProductPerCategory()
    {
        var product = new Product { Id = 1, Name = "Burger", Price = 10, Category = ProductCategory.Burger };

        _productRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);

        var createOrderDTO = new CreateOrderDTO(new List<CreateOrderItemDTO> {
            new(1, 1), new(1, 1)
        });

        Assert.ThrowsAsync<CustomResponseException>(async () => await _orderServices.CreateAsync(createOrderDTO));
    }

    [Test]
    public async Task CreateAsync_ShouldSucceed_WithValidOrder()
    {
        var product = new Product { Id = 1, Name = "Burger", Price = 10, Category = ProductCategory.Burger };

        _productRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
        _discountServicesMock.Setup(x => x.CalculateDiscount(It.IsAny<Order>())).Returns(0);

        var createOrderDTO = new CreateOrderDTO(new List<CreateOrderItemDTO> { new(1, 1) });

        _orderRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Order>())).ReturnsAsync((Order o) => o);
        _orderRepositoryMock.Setup(x => x.SaveAsync()).ReturnsAsync(1);

        var result = await _orderServices.CreateAsync(createOrderDTO);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.OrderItems.Count, Is.EqualTo(1));
    }

    [Test]
    public void UpdateAsync_ShouldThrow_WhenOrderNotFound()
    {
        _orderRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Order)null!);

        var updateOrderDTO = new UpdateOrderDTO(new List<CreateOrderItemDTO> { new(1, 1) });

        Assert.ThrowsAsync<CustomResponseException>(async () => await _orderServices.UpdateAsync(1, updateOrderDTO));
    }


    [Test]
    public async Task GetAllAsync_WhenOrdersExist_ReturnsAllOrders()
    {
        var orders = new List<Order> {
            new Order { Id = 1 },
            new Order { Id = 2 }
        };
        _orderRepositoryMock.Setup(x => x.GetAllWithOrderItemsAsync()).ReturnsAsync(orders);

        var result = await _orderServices.GetAllAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task GetByIdAsync_WhenOrderExists_ReturnsOrder()
    {
        var order = new Order { Id = 1 };
        _orderRepositoryMock.Setup(x => x.GetByIdWithOrderItemsAsync(1)).ReturnsAsync(order);

        var result = await _orderServices.GetByIdAsync(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1));
    }

    [Test]
    public async Task DeleteAsync_WhenOrderExists_DeletesOrder()
    {
        _orderRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);
        _orderRepositoryMock.Setup(x => x.SaveAsync()).ReturnsAsync(1);

        await _orderServices.DeleteAsync(1);

        _orderRepositoryMock.Verify(x => x.DeleteAsync(1), Times.Once);
        _orderRepositoryMock.Verify(x => x.SaveAsync(), Times.Once);
    }
}
