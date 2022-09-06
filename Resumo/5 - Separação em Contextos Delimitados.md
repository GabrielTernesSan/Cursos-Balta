## Contextos Delimitados

Os contextos delimitados ou bounded contexts buscam delimitar o seu domínio complexo em contextos baseados nas intenções do negócio.

Imagine uma entidade chamada Funcionário, esta entidade representa o colaborador da empresa dentro da aplicação. No bounded context “Recursos Humanos” a entidade Funcionário possui uma modelagem que atende comportamentos como férias, salário, rescisão etc. No bounded context “TI” esta entidade possui uma modelagem que atende comportamentos como login, troca de senha, permissões etc.