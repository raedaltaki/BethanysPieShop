using BethanysPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPieRepository, MockPieRepository>();
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddTransient
//builder.Services.AddSingleton
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
