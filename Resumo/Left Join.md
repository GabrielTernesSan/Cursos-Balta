## Left/Right Join

### Left Join

```sql
SELECT TOP 10
  [Curso].[Id],
  [Curso].[Nome],
  [Categoria].[Id] AS [Categoria],
  [Categoria].[Nome]
FROM    
    [Curso]
-- O LEFT JOIN pegaria todos os cursos da tabela mesmo os que não tivessem "categoria"
LEFT JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]
```

### Right Join

`````sql
SELECT TOP 10
  [Curso].[Id],
  [Curso].[Nome],
  [Categoria].[Id] AS [Categoria],
  [Categoria].[Nome]
FROM    
    [Curso]
-- O RIGHT JOIN pegaria todas as Categorias da tabela mesmo os que não tivessem "curso" associado
RIGHT JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]
`````

### Full Join

`````sql
SELECT TOP 10
  [Curso].[Id],
  [Curso].[Nome],
  [Categoria].[Id] AS [Categoria],
  [Categoria].[Nome]
FROM    
    [Curso]
-- O FULL JOIN pegaria todas as Categorias e Cursos
FULL JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]
`````

### Full Outer Join

````sql
SELECT TOP 10
  [Curso].[Id],
  [Curso].[Nome],
  [Categoria].[Id] AS [Categoria],
  [Categoria].[Nome]
FROM    
    [Curso]
-- O FULL OUTER JOIN pegaria todas as Categorias e Cursos
FULL OUTER JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]
````

