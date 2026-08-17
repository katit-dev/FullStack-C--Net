using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

public class LogFilter : ActionFilterAttribute
{
    // Inject ILogger
    private readonly ILogger<LogFilter> _logger;

    public LogFilter(ILogger<LogFilter> logger)
    {
        _logger = logger;
    }

    public override async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        // Lấy ra action name
        var actionName = context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor
            ? controllerActionDescriptor.ActionName
            : context.ActionDescriptor.DisplayName;

        // Lấy ra parameter của action
        var parameters = context.ActionArguments;

        // Cho action chạy
        ActionExecutedContext? res = await next();

        // Lấy ra response của action
        var result = res.Result as ObjectResult;
        var response = result?.Value;

        // Log ra thông tin action name, parameters và response
        _logger.LogInformation(
            $" Day la log filter, Action: {actionName}, Parameters: {JsonSerializer.Serialize(parameters)}, Response: {JsonSerializer.Serialize(response)}"
        );
    }
}