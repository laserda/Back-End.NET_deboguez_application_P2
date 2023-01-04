using Microsoft.AspNetCore.Mvc.Razor;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
builder.Services.AddSingleton<ICart, Cart>();
builder.Services.AddSingleton<ILanguageService, LanguageService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "Resources"; })
    .AddDataAnnotationsLocalization();

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

var supportedCultures = new[] { "en-GB", "en-US", "en", "fr-FR", "fr" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures.ToArray())
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
