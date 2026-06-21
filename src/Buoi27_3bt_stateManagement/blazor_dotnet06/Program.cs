using blazor_dotnet06.Services;

var builder = WebApplication.CreateBuilder(args);

// DI - Dependency Injection

//setup server blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddHttpClient(); // thu vien dung de call api tu server khac
builder.Services.AddSignalR(); // thu vien dung de tao ket noi socket tu server den client

// DI cac service management
builder.Services.AddScoped<NumberService>();
// dang ky service vao DI, khi co component goi den thi se tao ra 1 doi tuong moi cua service va cung cap cho component do su dung, khi component do bi huy thi doi tuong service do cung bi huy theo
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<BurgerService>();
// truoc ap la DI(tiem cac service vao ung dung)
var app = builder.Build();
// sau app la su dung cac ham tu service


app.UseRouting();
app.MapBlazorHub();// kich hoat server socket cua blazor web 
app.MapFallbackToPage("/_Host");// kich hoat file nay len chat dau tien

app.UseStaticFiles(); // kich hoat cac file css, js, image... trong wwwroot

app.Run();




