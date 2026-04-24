using GoodHamburger.API.Middlewares;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Application.Mappings;
using GoodHamburger.Application.Services;
using GoodHamburger.Domain.Interfaces.Repositories;
using GoodHamburger.Domain.Interfaces.Repositories.Base;
using GoodHamburger.Infrastructure.Repositories;
using GoodHamburger.Infrastructure.Repositories.Base;

namespace GoodHamburger.API.Extensions;

public static class ExtensionsMethods
{
    public static void AddApplicationDI(this IServiceCollection services)
    {
        services.AddScoped<IOrderServices, OrderServices>();
        services.AddScoped<IDiscountServices, DiscountServices>();
    }

    public static void AddInfrastructureDI(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    public static void RegisterMappings(this IServiceCollection services)
    {
        services.OrderRegisterMappings();
    }

    public static void AddMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
