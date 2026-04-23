using GoodHamburger.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace GoodHamburger.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomResponseException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode ?? (int)HttpStatusCode.BadRequest;

            var result = JsonSerializer.Serialize(new { error = ex.Message });

            await context.Response.WriteAsync(result);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = "Ocorreu um erro inesperado.", details = ex.Message });
            await context.Response.WriteAsync(result);
        }
    }
}
