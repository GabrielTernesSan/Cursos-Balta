## Service Descriptor

- Descreve **como resolver** uma dependência
- Determina o **tipo** e **tempo de vida** dela
- *AddTransient, AddScoped* e *AddSingleton* são "wrapers" deste item

`````c#
var decriptor = new ServiceDescriptor(
	typeof(IService), // Abstração
    typeof(ServiceOne), // Implementação
    ServiceLifeTime.Singleton); // Tempo de vida

builder.Services.Add(decriptor);
`````

