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

