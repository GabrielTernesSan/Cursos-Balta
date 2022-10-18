using DependencyStore.Repositories.Contracts;
using DependencyStore.Repositories;
using DependencyStore.Services.Contracts;
using DependencyStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Transient -> Toda vez que passar pelo contrutor será feita uma nova instância
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();