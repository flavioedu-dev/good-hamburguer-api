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
    }
}
