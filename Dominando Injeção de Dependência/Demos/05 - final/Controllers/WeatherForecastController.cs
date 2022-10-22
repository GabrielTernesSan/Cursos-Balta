using Microsoft.AspNetCore.Mvc;
using ResolvingDependencies.Attributes;
using ResolvingDependencies.Services;

namespace ResolvingDependencies.Controllers;

[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _service;

    public WeatherController(IWeatherService service)
        => _service = service;

    [HttpGet("/")]
    public IEnumerable<WeatherForecast> Get2([FromServices] IWeatherService service)
        => service.Get();

    [ApiKey]
    [HttpGet("/")]
    public IEnumerable<WeatherForecast> Get()
        => _service.Get();

    [HttpGet("/from-services")]
    public IEnumerable<WeatherForecast> GetFromServices(
        IWeatherService service)
        => service.Get();
}