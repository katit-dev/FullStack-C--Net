using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;



public class ExceptionActionFilter : Attribute, IExceptionFilter
{

    private readonly ILogger<ExceptionActionFilter> _logger;
    public ExceptionActionFilter(ILogger<ExceptionActionFilter> logger){
        _logger = logger;
    }
  
    public void OnException(ExceptionContext context)
    {
        //ghi log lỗi ra console
        _logger.LogError($"Đây là log filter: Exception: {context.Exception.Message}, StackTrace: {context.Exception.StackTrace}");

        //trả về response lỗi (chỉnh lại response body để trả về thông tin lỗi)
        context.Result = new ObjectResult(new
        {
            Message = "Đã xảy ra lỗi trong quá trình xử lý yêu cầu.",
            // Exception = context.Exception.Message,
            // StackTrace = context.Exception.StackTrace
        })
        {
            StatusCode = 500
        };
        
    }
}