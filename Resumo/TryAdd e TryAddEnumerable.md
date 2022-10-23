## TryAdd e TryAddEnumerable

### TryAdd*

- Inverte o comportamento
- Não dá erro, mas não duplica
  - Se já tiver um serviço registrado ele não irá registrar novamente
- Compara apenas abstração
  - Não registra duas implementações para uma mesma abstração (Interface)

```c#
builder.Services.TryAddTransient<IService, ServiceOne>();
builder.Services.TryAddTransient<IService, ServiceOne>();
builder.Services.TryAddTransient<IService, ServiceOne>();
builder.Services.TryAddTransient<IService, ServiceTwo>();
```

Neste caso acima ele só registraria um serviço.

- Só vai registrar o **primeiro** item
- Como já existe um implementação registrada para a interface **IService**, vai ignorar as próximas tentativas de registro.

### TryAddEnumerable

- TryAddEnumerable
- Permite registrar ambos (1 e 2)
- Porém não permite duplicar (2 e 2 por exemplo)
- Único (interface e implementação)