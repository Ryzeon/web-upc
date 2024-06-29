using System.Data;
using System.Net;

namespace si730pc2u20221a322.API.Shared.Interfaces.Middleware;

/// <summary>
/// Middleware for handling exceptions in the application.
/// Allowing to return a custom message and status code.
/// </summary>
/// <author>Alex Avila Asto (u20221a322) </author>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// If an exception is thrown, this method will handle it and return a custom message and status code.
    /// Returning a json object with the message.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="ex"></param>
    /// <author>Alex Avila Asto (u20221a322) </author>
   private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.BadRequest;
        var result = ex.Message;
        
        // Add handlers for custom exeptions.

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        var jsonResult = System.Text.Json.JsonSerializer.Serialize(new { message = result });
        await context.Response.WriteAsync(jsonResult);
    }
}
