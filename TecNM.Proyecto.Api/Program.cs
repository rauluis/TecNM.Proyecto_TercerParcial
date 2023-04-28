using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Repositories;

using Dapper.Contrib.Extensions;
using TecNM.Proyecto.Api.DataAccess;
using TecNM.Proyecto.Api.DataAccess.Interfaces;


using TecNM.Proyecto.Api.Services.interfaces;
using TecNM.Proyecto.Api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<IProductCategoryRepository, InMemoryProductCategoryRepository>();
//builder.Services.AddSingleton<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IBrandService,BrandService>();
builder.Services.AddScoped<IBrandRepository,BrandRepository>();

builder.Services.AddScoped<IProductCategoryRepository,ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryService,ProductCategoryService>();

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();

builder.Services.AddScoped<IOrderDetailsService,OrderDetailsService>();
builder.Services.AddScoped<IOrderDetailsRepository,OrderDetailsRepository>();

builder.Services.AddScoped<IOrder1Service,Order1Service>();
builder.Services.AddScoped<IOrder1Repository,Order1Repository>();


builder.Services.AddScoped<IDbContext, DbContext>();


SqlMapperExtensions.TableNameMapper = entityType =>{

    var name = entityType.ToString();
    if(name.Contains("TecNM.Proyecto.Core.Entities."))
        name = name.Replace("TecNM.Proyecto.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
