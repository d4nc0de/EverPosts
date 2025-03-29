using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;

namespace EverPostWebApi.Config
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
                _logger.LogError(ex, $"Ooooops! Algo salió mal: (ex.Message)");
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        public static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception) 
        {
            context.Response.ContentType = "aplication/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails()
            {
                StatusCode = StatusCodes.Status406NotAcceptable,
                Message = "Algo salio mal. Error!",
                StackTrace = exception.StackTrace
            }));
        }
    }
}
