using System.Text;
using backend_netcore_dotnet06.Helper;
using backend_netcore_dotnet06.Models.DBQuanLyNhanVien;
using backend_netcore_dotnet06.Models.DBUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Models.Models;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "FileServer"
});

//DI QuanLyNhanVienContext
string? connectionStringQLNV = builder.Configuration.GetConnectionString("DBQuanLyNhanVienConnection");

// DI DbContext (EF - entity framework) QuanLyNhanVienContext
// DI cho userdb context
string? connectionStringUser = builder.Configuration.GetConnectionString("DBUser");

builder.Services.AddDbContext<UserDBContext>(options =>
{
    options.UseSqlServer(connectionStringUser);
});

builder.Services.AddDbContext<QuanLyNhanVienContext>(options => options.UseSqlServer(connectionStringQLNV));

//DI Layzy proxy
//builder.Services.AddDbContext<QuanLyNhanVienContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionStringQLNV));
// builder.Services.AddDbContext<QuanLyNhanVienContext>(options =>
// {
//     options.UseSqlServer(connectionStringQLNV);
//     // .UseLazyLoadingProxies(false);
// });

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

// DI CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGetData", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5500",
                "http://127.0.0.1:5500"
            )
            .WithMethods("GET")
            .AllowAnyHeader();
    });

    options.AddPolicy("AllowPostProduct", policy =>
    {
        policy.WithOrigins(
                "http://127.0.0.1:5500",
                "http://127.0.0.1:5501"
            )
            .WithMethods("POST")
            .AllowAnyHeader();
    });
});

// DI JWT
var jwtKey = builder.Configuration["Jwt:Key"];
var issuer = builder.Configuration["Jwt:Issuer"];
var audience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
ValidateIssuer = true,
ValidateAudience = true,
ValidateLifetime = true,
ValidateIssuerSigningKey = true,

ValidIssuer = issuer,
ValidAudience = audience,
IssuerSigningKey = new SymmetricSecurityKey(
Encoding.UTF8.GetBytes(jwtKey)
)
};
});
builder.Services.AddAuthorization();

// DI JwtService
builder.Services.AddScoped<JwtAuthService>();

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

// middleware exception handler
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var request = context.Request;
        var ipAddress = request.HttpContext.Connection.RemoteIpAddress?.ToString();
        var userAgent = request.Headers["User-Agent"].ToString();

        var result = new
        {
            IsSuccess = false,
            Message = "Co loi trong he thong",
            IpAddress = ipAddress,
            UserAgent = userAgent
        };

        await context.Response.WriteAsJsonAsync(System.Text.Json.JsonSerializer.Serialize(result));
    });
});

// su dung middleware CORS
app.UseCors("AllowGetData");
app.UseCors("AllowPostProduct");
// app.UseStaticFiles(); // su dung middleware static file

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "FileServer")
    ),
    RequestPath = "/files"
});

app.UseAuthentication();
app.UseAuthorization();
// su dung middleware controller
app.MapControllers();

app.Run();
