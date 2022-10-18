using DependencyStore.Repositories.Contracts;
using DependencyStore.Repositories;
using DependencyStore.Services.Contracts;
using DependencyStore.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

/* 
    Preciso resolver o SqlConnection também, porém se usar Transient toda vez que passar pelo construtor ele cria 
    uma nova conexão. O ideal é criarmos a menor quantidade de conexões possíveis, por isso, usamos o AddScoped
    que cria uma conexão por requisição
*/

builder.Services.AddScoped<SqlConnection>(x
    => new SqlConnection("CONN_STRING")
);

// Transient -> Toda vez que passar pelo contrutor será feita uma nova instância
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();