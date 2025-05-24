using Microsoft.AspNetCore.Authentication.Cookies;
using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient(); // Web API ye ba�lant� kurup api yi kullanarak veritaban� i�lemleri yapmak i.in bu servisi ekledik

builder.Services.AddDbContext<DatabaseContext>(); // DatabaseContext dosyas�n� bu �ekilde servis olarak projeye ekliyoruz
// Authentication : Oturum a�ma - giri� yapma i�lemi
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // admin giri� adresimiz budur dedik
    x.Cookie.Name = "Administrator"; // olu�acak kukinin ad�
});

// Authorization : giri� yapan kullan�c�n�n nelere yetkisi var?
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin")); // Admin kullan�c� yetkisi
    options.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "User")); //
});
// Container
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryService)); // Repository s�n�f�n� servis olarak kullanabilmek i�in
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<IBrandService, BrandService>(); // servis eklemek i�in di�er yaz�m tarz�

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
