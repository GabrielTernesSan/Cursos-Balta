## Rastreamento

Quando consultamos entidades usando o entity framework ele guarda as entidades no contexto, realizando o que é conhecido como **tracking(rastreamento)** das entidades. Ele faz isso para acompanhar o estado das entidades.

Sempre que uma consulta é executada as entidades são carregadas no rastreador de estado dos objetos. Isso é feito para rastrear quais alterações foram feitas no modelo de entidades durante a vida do contexto, de forma que uma chamada ao método **SaveChanges** irá realizar as consultas SQL requeridas no banco de dados.

Esse é recurso poderoso mas ele adiciona uma sobrecarga considerável que afeta o desempenho das consultas que são rastreadas. As consultas que não são rastreadas tem um desempenho melhor.

Uma solução para isso é usar o método **AsNoTracking**.

O método de extensão **AsNoTracking**() retorna uma nova consulta e as entidades retornadas não serão armazenadas em **cache** pelo contexto (**DbContext**). Isto significa que o Entity Framework não efetua qualquer processamento ou armazenamento adicional das entidades que são devolvidos pela consulta.

Utilizar o **AsNoTracking** significa que as entidades serão lidas da origem de dados mas não serão mantidas no contexto.