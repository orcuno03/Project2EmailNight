using Microsoft.AspNetCore.Identity;
using Project2EmailNight.Context;
using Project2EmailNight.Entities;
using Project2EmailNight.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmailContext>();

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<EmailContext>()
    .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/UserLogin"; 
    options.AccessDeniedPath = "/Login/UserLogin"; 
});

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
