using GoodHamburger.Application.DTOs.Orders;
using GoodHamburger.Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburger.Application.Mappings;

public static class MappingConfigurations
{
    public static void OrderRegisterMappings(this IServiceCollection services)
    {
        TypeAdapterConfig<Order, OrderDTO>.NewConfig(); 

        TypeAdapterConfig<Product, OrderItem>.NewConfig()
            .Map(dest => dest.Id, src => 0)
            .Map(dest => dest.ProductId, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Category, src => src.Category);
    }
}
