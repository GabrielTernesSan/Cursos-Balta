using ResolvingDependencies.Services;

var builder = WebApplication.CreateBuilder(args);

// Sempre uma nova instância
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

// Resolvendo dependências no Program
using (var scope = app.Services.CreateScope())
{
    var service = scope
        .ServiceProvider
        .GetRequiredService<IWeatherService>();

    service.Get();
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();
