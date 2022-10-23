### Group By

`````sql
SELECT TOP 100
    [Categoria].[Nome],
    -- O resultado de um COUNT, AVG, SUM tem que sempre estar associado a um GROUP BY
    COUNT([Curso].[CategoriaId]) AS [Cursos]
FROM    
    [Categoria]
    INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
-- Agrupa o resultado
GROUP BY
    [Categoria].[Nome],
    [Curso].[CategoriaId]
`````

```sql
SELECT TOP 100
	-- Se for aqui
	[Categoria].[Id],
    [Categoria].[Nome],
    COUNT([Curso].[CategoriaId]) AS [Cursos]
FROM    
    [Categoria]
    INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY
	-- Tem que ir aqui também
	[Categoria].[Id],
    [Categoria].[Nome],
    [Curso].[CategoriaId]
```

