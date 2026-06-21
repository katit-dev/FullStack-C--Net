using blazor_dotnet06.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
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



app.UseRouting();
app.MapBlazorHub(); //kích hoạt server socket của blazor web
app.MapFallbackToPage("/_Host");

app.UseStaticFiles(); // middleware để sử dụng file tĩnh như css, js, img

app.MapHub<RoomHub>("/roomhubs"); //Đường dẫn để client kết nối đến server socket của .net có phân biệt hoa thường


app.Run();

