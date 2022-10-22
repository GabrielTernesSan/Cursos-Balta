using DependencyInjectionLifetimeSample.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.TryAddTransient<IService, PrimaryService>();
// builder.Services.TryAddTransient<IService, PrimaryService>();
// builder.Services.TryAddTransient<IService, SecondaryService>();

// var descriptor = new ServiceDescriptor(
//     typeof(IService),
//     typeof(PrimaryService),
//     ServiceLifetime.Transient
// );

builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, PrimaryService>()); // Permite
builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, PrimaryService>()); // Permite
// Não permite pois é uma implementação de um outro serviço para a mesma interface
// builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, SecondaryService>()); // Não permite

var app = builder.Build();

app.MapGet("/", (IEnumerable<IService> services)
    => Results.Ok(services.Select(x => x.GetType().Name)));

app.Run();

public interface IService
{
}