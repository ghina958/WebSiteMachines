using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSiteMachines.Data;
using WebSiteMachines.Helpers;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using WebSiteMachines.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDashboardAdminService, DashboardAdminService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();

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
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
