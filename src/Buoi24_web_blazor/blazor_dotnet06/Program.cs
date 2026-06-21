var builder = WebApplication.CreateBuilder(args);

// DI - Dependency Injection

//setup server blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddHttpClient(); // thu vien dung de call api tu server khac

// truoc ap la DI(tiem cac service vao ung dung)
var app = builder.Build();

// sau app la su dung cac ham tu servie
app.UseRouting();
app.MapBlazorHub();// kich hoat server socket cua blazor web 
app.MapFallbackToPage("/_Host");// kich hoat file nay len chat dau tien

app.Run();




