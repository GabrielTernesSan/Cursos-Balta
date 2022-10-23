## Joins

```sql
SELECT TOP 100
  *
FROM    
    [Curso]
-- Junta a tabela "Categoria" com a de "Curso"
INNER JOIN [Categoria] -- (Intersecção)
-- Mas precisamos informar como será feita a junção
    ON [Curso].[CategoriaId] = [Categoria].[Id]
```

````sql
SELECT TOP 100
  -- Se colocarmos somente o [Id] com o JOIN ele vai dar erro dizendo que o nome é ambíguo
  -- pois nas duas tabelas temos a coluna [Id]
  [Id]
FROM    
    [Curso]
-- Junta a tabela "Categoria" com a de "Curso"
INNER JOIN [Categoria] -- (Intersecção)
-- Mas precisamos informar como será feita a junção
    ON [Curso].[CategoriaId] = [Categoria].[Id]
````

````sql
SELECT TOP 100
  -- Então usamos o [(Nome da table)].[(campo)]
  [Curso].[Id],
  [Curso].[Nome],
  [Categoria].[Id] AS [Categoria],
  [Categoria].[Nome]
FROM    
    [Curso]
-- Junta a tabela "Categoria" com a de "Curso"
INNER JOIN [Categoria] -- (Intersecção)
-- Mas precisamos informar como será feita a junção
    ON [Curso].[CategoriaId] = [Categoria].[Id]
````

````sql
SELECT TOP 10
  [Curso].[Id],
  [Curso].[Nome],
  [Categoria].[Id] AS [Categoria],
  [Categoria].[Nome]
FROM    
    [Curso]
INNER JOIN [Categoria]
    ON [Curso].[CategoriaId] = [Categoria].[Id]
-- Podemos ter vários "JOIN"
INNER JOIN [TabelaY]
    ON [Curso].[CategoriaId] = [Categoria].[Id]
````

