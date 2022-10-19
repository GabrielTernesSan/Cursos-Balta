using DependencyInjectionLifetimeSample.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IService, PrimaryService>();


var app = builder.Build();

app.MapGet("/", (IService services)
    => Results.Ok(services.GetType().Name));

app.Run();

public interface IService
{
}