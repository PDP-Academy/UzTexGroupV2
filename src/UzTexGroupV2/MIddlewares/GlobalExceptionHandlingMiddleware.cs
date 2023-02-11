using System.Net;
using System.Text.Json;
using UzTexGroupV2.Domain;

namespace UzTexGroupV2.MIddlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (InvalidIdException invalidIdException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var serializedObject = JsonSerializer.Serialize(new
            {
            invalidIdException.Message
            });

            await HandleExceptionAsync(context, serializedObject);
        }
        catch(NotFoundException notFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var serializedObject = JsonSerializer.Serialize(new
            {
                notFoundException.Message
            });

            await HandleExceptionAsync(context, serializedObject);
        }
        catch(Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var serializedObject = JsonSerializer.Serialize(new
            {
                exception.Message
            });

            await HandleExceptionAsync(context, serializedObject);
        }
    }
    private async Task HandleExceptionAsync(
        HttpContext context,
        string message)
    {
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(message);
    }
}
