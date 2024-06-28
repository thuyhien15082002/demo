using Microsoft.EntityFrameworkCore;
using ReponsitoryMVC;
using ReponsitoryMVC.Models;
using ReponsitoryMVC.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Đăng ký IProductRepository
builder.Services.AddScoped<IProductRepository<Product>, ProductRepository<Product>>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ValidateStatusMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Product}/{id?}");

app.Run();
