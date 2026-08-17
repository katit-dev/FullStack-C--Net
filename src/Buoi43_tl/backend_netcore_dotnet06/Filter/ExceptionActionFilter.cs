using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ExceptionActionFilter : Attribute, IExceptionFilter
{
    private readonly ILogger<LogFilter> _logger;

    public ExceptionActionFilter(ILogger<LogFilter> logger)
    {
        _logger = logger;
    }
    public void OnException(ExceptionContext context)
    {
        // Ghi log lỗi ra console/file
        _logger.LogError(
            $"Đây là log filter: Exception: {context.Exception.Message}, StackTrace: {context.Exception.StackTrace}"
        );

        // Trả về response lỗi, không để lộ chi tiết exception cho client
        context.Result = new ObjectResult(new
        {
            Message = "Đã xảy ra lỗi trong quá trình xử lý yêu cầu."

            // Không nên trả lỗi thật ra client
            // Exception = context.Exception.Message,
            // StackTrace = context.Exception.StackTrace
        })
        {
            StatusCode = 500
        };
    }
}