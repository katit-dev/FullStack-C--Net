using backend_netcore_dotnet06.Helper;
using backend_netcore_dotnet06.Models.DBQuanLyNhanVien;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Models.Models;

var builder = WebApplication.CreateBuilder(args);

//DI QuanLyNhanVienContext
string? connectionStringQLNV = builder.Configuration.GetConnectionString("DBQuanLyNhanVienConnection");

builder.Services.AddDbContext<QuanLyNhanVienContext>(options => options.UseSqlServer(connectionStringQLNV));

//DI Layzy proxy
//builder.Services.AddDbContext<QuanLyNhanVienContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionStringQLNV));
builder.Services.AddDbContext<QuanLyNhanVienContext>(options => options.UseSqlServer(connectionStringQLNV)
.UseLazyLoadingProxies(false));

// DI AutoMapper
// builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// DI DbContext (EF - entity framework)
builder.Services.AddDbContext<ProductStoreContext>();

// DI controller co [Route]
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

// su dung middleware controller
app.MapControllers();

app.Run();
