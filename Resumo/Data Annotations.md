## Tipos de mapeamento

### Tipos

- Fluent Mapping
  - Mapeamento fluente
  - Feito em uma classe externa
  - Não "polui" a classe principal
  - Não cria dependências na classe/projeto principal
- Data Annotations
  - Feitos diretamente nas classes
  - Mais simples e diretos
  - Dependem do `System.ComponentModel.DataAnnotations`
    - Alguns dependem do `Microsoft.EntityFrameworkCore` também