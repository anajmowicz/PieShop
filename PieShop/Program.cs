using Microsoft.EntityFrameworkCore;
using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<PieShopDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("PieShopDbContextConnection")));
var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}   
app.MapDefaultControllerRoute();
app.MapRazorPages();
DbInitializer.Seed(app);
app.Run();
