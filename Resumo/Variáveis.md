## Variáveis

````sql
-- Pega os cursos com Id igual a 2
CREATE OR ALTER PROCEDURE [spListaCursos] AS
	DECLARE @Id INT
	SET @Id = 2
	
	SELECT * FROM [Curso]

	SELECT * FROM [Curso] WHERE [Id] = @Id

EXEC [spListaCursos]

DROP PROCEDURE [spListaCursos]
````

````sql
-- Pega os cursos com o Id da categoria "Backend"
CREATE OR ALTER PROCEDURE [spListaCursos] AS
	DECLARE @CategoriaId INT
	SET @CategoriaId = (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Nome] = 'Backend')
	
	SELECT * FROM [Curso]

	SELECT * FROM [Curso] WHERE [CategoriaId] = @CategoriaId

EXEC [spListaCursos]

DROP PROCEDURE [spListaCursos]
````

````sql
-- Podemos esperar um parâmetro de entrada também
CREATE OR ALTER PROCEDURE [spListaCursos] 
	@Category NVARCHAR(80)
AS
	DECLARE @CategoriaId INT
	SET @CategoriaId = (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Nome] = @Category)
	
	SELECT * FROM [Curso]

	SELECT * FROM [Curso] WHERE [CategoriaId] = @CategoriaId
````

```sql
EXEC [spListaCursos] 'Backend'
EXEC [spListaCursos] 'Frontend'
EXEC [spListaCursos] 'Mobile'
```

````sql
-- Podemos esperar múltiplos parâmetros de entrada também
CREATE OR ALTER PROCEDURE [spListaCursos] 
	@Category NVARCHAR(80),
	@teste NVARCHAR(60)
AS
	DECLARE @CategoriaId INT
	SET @CategoriaId = (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Nome] = @Category)
	
	SELECT * FROM [Curso]

	SELECT * FROM [Curso] WHERE [CategoriaId] = @CategoriaId
````

````sql
EXEC [spListaCursos] 'Backend', 'Teste'
````

