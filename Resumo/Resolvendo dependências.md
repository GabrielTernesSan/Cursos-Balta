## Resolvendo dependências

- Construtor
- Na assinatura do método
- No Program
- No HttpContext

### Construtor

`private readonly`

`````c#
private readonly IRelatorioRepository repository;
`````

**Diferença de readonly e const**

Const você define uma constante, ao declará-la você precisa atribuir um valor.

O readonly ela vai poder ser inicializada no construtor, somente nele.

### Na assinatura do método

- Obtém direto dos serviços

- Recomendado para situações que só tem uma dependência e vai ser usado somente naquele método

- No .NET 7 não precisa mais especificar `[FromServices]`

  ````c#
  [HttpGet("/")]
  public IEnumerable<WatherForecast> Get(
  	[FromServices]IWaterService service)
      => service.Get();
  
  // .NET 7
  [HttpGet("/")]
  public IEnumerable<WatherForecast> Get(
  	IWaterService service)
      => service.Get();
  ````

### No Progam.cs

`````c#
var app = builder.Build();
// Tem que acontecer da linha "var app" para baixo
using (var scope = app.Services.CreatScope()) // Garante que os serviços da aplicação já estão registrados
{
    var services = scope.ServiceProvider; // Item que fornece o serviço para nós. Dado uma interface ele retorna o serviço. Traz todos os serviços registrados
    
    var repository = services.GetRequiredService<ICustomerRepository>(); // Pega a instância de um serviço registrado services.GetRequiredService<(interface)>()
    repository.CreateAsync(new Customer("Gabriel"));
}
`````

### Via HttpContext

- Podemos "recuperar" os serviços registrados utilizando o `HttpContext`

````c#
public async Task OnActionExecutionAsync(
		ActionExecutingContext context,
		ActionExecutionDelegate next)
{
    var service = context
        .HttpContext
        .RequestServices
        .GetService<IWatherService>();
    
    var forecasts = service.Get();
}
````