using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);



// DI controller có [Route]
builder.Services.AddControllers();
// DI Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API documentation for .NET 10"
    });
});


var app = builder.Build();

//Nếu là localhost (môi trường dev mới có trang swagger)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = "swagger";
    });
}

// Sử dụng middleware để định tuyến đến controller
app.MapControllers();


app.Run();
