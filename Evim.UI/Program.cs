
using Evim.DAL.Content;
using Evim.BL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    opt.LoginPath = "/admin/login"; //yetkisi olmadan giri� yapmaya �al��t���nda
    opt.LogoutPath = "/admin/logout"; // s�re doldu�unda gidece�i sayfa

}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}"); ;
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //kimlik do�rulama
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.Run();
