using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CustomerManagementApi.Middlewares
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
      _next = next;
      _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"An unhandled exception occurred: {ex.Message}");
        await HandleExceptionAsync(httpContext);
      }
    }

    private static Task HandleExceptionAsync(HttpContext context)
    {
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      context.Response.ContentType = "application/json";

      var response = new
      {
        StatusCode = context.Response.StatusCode,
        Message = "An unexpected error occurred. Please try again later."
      };

      var jsonResponse = JsonSerializer.Serialize(response);

      return context.Response.WriteAsync(jsonResponse);
    }
  }
}
