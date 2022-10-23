## AddTransient, AddScoped, AddSingleton

### AddTransient

- Sempre cria uma **nova instância** do objeto
- Ideal para cenários onde queremos sempre **um novo objeto**

### AddScoped

- Cria **um objeto** por transação
- Se você chamar 2 ou mais serviços que dependem do **mesmo objeto**, a mesma instância será utilizada
- Ideal para cenários onde queremos **apenas um objeto** por requisição (Banco)

### AddSingleton

- Padrão que visa garantir **apenas um instância** de um objeto para **aplicação toda**
- Um bom exemplo são as **configurações**
  - Uma vez carregadas, **ficam até a aplicação reiniciar**
- Cria **um objeto** quando a aplicação inicia
- **Mantém este objeto** na memória até a aplicação parar ou reiniciar
- Sempre devolve a **mesma instância** deste objeto, com os mesmos valores