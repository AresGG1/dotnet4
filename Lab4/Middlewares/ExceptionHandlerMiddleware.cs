using System.Net;
using System.Text;
using Domain.Exceptions;
using Infrastructure.Exceptions;

namespace Lab4.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    
    public ExceptionHandlerMiddleware(RequestDelegate next) => _next = next;
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (FlightDestinationConflictException e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await SetMessage(httpContext.Response, e.Message);
        }
        catch (EntityNotFoundException e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await SetMessage(httpContext.Response, e.Message);
        }
        catch (Exception e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }

    private async Task SetMessage(HttpResponse response, string message)
    {
        response.ContentType = "text/plain";
        await response.Body.WriteAsync(ConvertToBytes(message));
    }
    private byte[] ConvertToBytes(string message)
    {
        return Encoding.UTF8.GetBytes(message);
    }
}