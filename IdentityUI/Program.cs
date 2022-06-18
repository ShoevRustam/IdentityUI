using IdentityUI.Data;
using IdentityUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Roles",
        builder => builder.RequireRole("Admin"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
{
    config.Lockout.MaxFailedAccessAttempts = 5;
    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;
    config.Password.RequireUppercase = false;
    config.Password.RequireNonAlphanumeric = false;
})
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Cookie";
    config.LoginPath = "/Account/Login";
    config.AccessDeniedPath = "/Account/AccessDenied";
    config.Cookie.HttpOnly = true;
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromSeconds(50);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
     );
    endpoints.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
    app.Run();
});



