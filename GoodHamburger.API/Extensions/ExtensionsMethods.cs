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
    public static void RegisterMappings(this IServiceCollection services)
    {
        services.OrderRegisterMappings();
    }

    public static void AddMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
