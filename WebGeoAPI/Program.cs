using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebGeo.BLL.Services;
using WebGeoInfrastructure.Interfaces.Repositories;
using WebGeoInfrastructure.Interfaces.Services;
using WebGeoRepository;
using WebGeoRepository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DB"), psqloptions => psqloptions.UseNetTopologySuite()));

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IShopRepository, ShopRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IShopService, ShopService>();

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
