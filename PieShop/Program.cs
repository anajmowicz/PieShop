using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();

var app = builder.Build();

app.UseStaticFiles();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}   
app.MapDefaultControllerRoute();
app.Run();
