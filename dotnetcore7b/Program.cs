using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repo.IRepo;
using Bulky.DataAccess.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using DNW.Areas.Identity.Data;
using DNW.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddDefaultIdentity<DNWUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DNWContext>();



builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Options =>
{
    Options.LoginPath = "/Access/LogIn";
    Options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

});



//builder.Services.AddDefaultIdentity<IdentityUser>(... )
//    .AddRoles<IdentityRole>()...

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
 //builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
