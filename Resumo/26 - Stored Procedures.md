## Stored Procedures

Stored Procedure, que traduzido significa Procedimento Armazenado, é uma conjunto de comandos em **SQL** que podem ser executados de uma só vez, como em uma função. Ele armazena tarefas repetitivas e aceita parâmetros de entrada para que a tarefa seja efetuada de acordo com a necessidade individual.

Há cinco tipos de procedures básicos que podemos criar:

- Procedimentos Locais - São criados a partir de um banco de dados do próprio usuário;
- Procedimentos Temporários - Existem dois tipos de procedimentos temporários: Locais, que devem começar com # e Globais, que devem começar com ##;
- Procedimentos de Sistema - Armazenados no banco de dados padrão do SQL Server (Master), podemos indentifica-los com as siglas sp, que se origina de stored procedure. Tais procedures executam as tarefas administrativas e podem ser executadas a partir de qualquer banco de dados.
- Procedimentos Remotos - Podemos usar Queries Distribuídas para tais procedures. São utilizadas apenas para compatibilidade.
- Procedimentos Estendidos - Diferente dos procedimentos já citados, este tipo de procedimento recebe a extensão .dll e são executadas fora do SGBD SQL Server. São identificadas com o prefixo xp.

`````sql
CREATE PROCEDURE [spListaCursos] AS
	SELECT * FROM [Curso]
`````

````sql
EXEC [spListaCursos]
````

````sql
DROP PROCEDURE [spListaCursos]
````

