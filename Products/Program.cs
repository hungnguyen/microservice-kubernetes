using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ProductsContext") ?? throw new InvalidOperationException("Connection string 'ProductsContext' not found")));
// Add services to the container.


var app = builder.Build();

//config the HTTP request pipline
app.MapProductEnpoints();

app.UseStaticFiles();

app.CreateDbIfNotExists();

app.Run();
