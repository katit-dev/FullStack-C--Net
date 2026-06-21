using blazor_dotnet06.Services;

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;





var builder = WebApplication.CreateBuilder(args);

//DI các thư viện cho ứng dụng


//setup server blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(); 

builder.Services.AddHttpClient(); //Thư viện dùng để call api từ server khác

//Trước app là DI (tiêm các service vào ứng dụng)
//Sử dụng các hàm từ service
builder.Services.AddSignalR(); //service socket của dotnet




//DI các service management
builder.Services.AddScoped<NumberService>();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<BurgerService>();
builder.Services.AddScoped<StoreService>();
builder.Services.AddScoped<RoomService>();

//DI phân quyền blazor component

//DI phân quyền jwt
// Cấu hình accesstoken jwt
var key = builder.Configuration["Jwt:Key"];           // Khóa bí mật để ký token
var issuer = builder.Configuration["Jwt:Issuer"];     // Issuer (bên phát hành token)
var audience = builder.Configuration["Jwt:Audience"]; // Audience (người nhận token)
// 2. Cấu hình Authentication sử dụng JWT Bearer
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {

        ValidateIssuerSigningKey = true, // Xác thực key bí mật của token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateIssuer = true,// Xác thực Issuer 
        ValidIssuer = issuer, // Phải khớp với Issuer trong token
        ValidateAudience = true,    // Xác thực Audience
        ValidAudience = audience, // Phải khớp với Audience trong token
        ValidateLifetime = true, // Xác thực thời gian hết hạn của token
        ClockSkew = TimeSpan.Zero, // Bỏ qua độ trễ thời gian giữa server và client (ngăn lỗi thời gian)
        RoleClaimType = ClaimTypes.Role, // Ánh xạ claim role
        NameClaimType = ClaimTypes.Name,
    };
});

// 3. Cấu hình Authorization (Phân quyền theo Role)
builder.Services.AddAuthorization(options =>
{
    // Chính sách chỉ cho phép Admin truy cập
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    // Chính sách chỉ cho phép User truy cập
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});
// 4. Thêm AuthorizationCore để sử dụng trong Blazor Components (Phần view)
builder.Services.AddAuthenticationCore(); //Xác thực token hợp lệ
builder.Services.AddAuthorizationCore(); //Xác thực vai trò (Role phân quyền)


// DI JWT
builder.Services.AddScoped<JwtAuthService>();

// DI thư viện lưu trữ localstorage của browser
builder.Services.AddBlazoredLocalStorage();

// DI custom check token
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();




//Khai báo cho client nào có thể connect được đến server
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});








var app = builder.Build();

app.UseCors("AllowFrontend");


// kich hoat ham phan quyen
app.UseAuthentication(); // kich hoat xac thuc token
app.UseAuthorization(); // kich hoat phan quyen


app.UseRouting();
app.MapBlazorHub(); //kích hoạt server socket của blazor web
app.MapFallbackToPage("/_Host");

app.UseStaticFiles(); // middleware để sử dụng file tĩnh như css, js, img

app.MapHub<RoomHub>("/roomhubs"); //Đường dẫn để client kết nối đến server socket của .net có phân biệt hoa thường


app.Run();

