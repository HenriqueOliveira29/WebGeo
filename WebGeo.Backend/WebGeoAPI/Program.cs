using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebGeo.BLL.Services;
using WebGeoInfrastructure.Interfaces.Repositories;
using WebGeoInfrastructure.Interfaces.Services;
using WebGeoRepository;
using WebGeoRepository.Repositories;


var builder = WebApplication.CreateBuilder(args);

string appSettingsFile = builder.Environment.EnvironmentName == "Development" ? $"appsettings.{builder.Environment.EnvironmentName}.json" : "appsettings.json";

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile(appSettingsFile, optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();



builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();

    builder.WithOrigins("http://localhost:8100", "https://localhost:8100")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), psqloptions => psqloptions.UseNetTopologySuite()));

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IShopRepository, ShopRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IStorageRepository, StorageRepository>();
builder.Services.AddTransient<IRoutesRepository, RoutesRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IShopService, ShopService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IStorageService, StorageService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
