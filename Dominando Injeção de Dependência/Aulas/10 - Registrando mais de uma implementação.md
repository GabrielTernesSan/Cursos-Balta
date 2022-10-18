## Registrando mais de uma implementação

- Se podemos ter mais de uma implementação por interface...

  ````c#
  public interface IService
  {    
  }
  ````

- O que acontece quando registramos mais de um serviço?

```c#
public class ServiceOne : IService
{
}

public class ServiceTwo : IService
{
}
```

```c#
builder.Services.AddTransient<IService, ServiceOne>();
builder.Services.AddTransient<IService, ServiceTwo>();
```

- Neste caso, como não especificamos a implementação, sempre será retornado a **última registrada**
- No exemplo seria o **ServiceTwo**

````c#
private readonly IService _service;

public OrderController(IService service)
{
    _service = service;
}

[Route("/")]
[HttpGet]
public IActionReslt Get()
{
    return Ok(new
    {
        _service.GetType().Name
    });
}
````

````c#
// Podemos inclusive fazer isto
builder.Services.AddTransient<IService, ServiceOne>();
builder.Services.AddTransient<IService, ServiceOne>();
builder.Services.AddTransient<IService, ServiceOne>();
// Porém é sempre o último que vai valer se não for especificado
builder.ServixesAddTransient<IService, ServiceTwo>();
````

- Porém não significa que o ASP.NET registrou só o último
- Se ao invés de recebermos um `IService`, no controller, nós esperarmos um `IEnumerable<IService>` ele vai trazer todas as instâncias registrada desse serviço

````c#
private readonly IEnumerable<IService> _service;

public OrderController(IService service)
{
    _service = service;
}

[Route("/")]
[HttpGet]
public IActionReslt Get()
{
    return Ok( _service.Select(x => x.GetType().Name));
}

[
    "ServiceOne",
    "ServiceOne",
    "ServiceOne",
    "ServiceTwo"
]
````

- Os serviços estão sendo registrados
- Porém o comportamento quando resolvemos um serviço é de **obter apenas o último**