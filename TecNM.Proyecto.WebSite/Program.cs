using TecNM.Proyecto.WebSite.Services;
using TecNM.Proyecto.WebSite.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrder1Service, Order1Service>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();