## Having

A cláusula HAVING determina uma condição de busca para um grupo ou um conjunto de registros, definindo critérios para limitar os resultados obtidos a partir do agrupamento de registros. É importante lembrar que essa cláusula só pode ser usada em parceria com GROUP BY.

> Obs: O HAVING é diferente do WHERE. O WHERE restringe os resultados obtidos **sempre** após o uso da cláusula FROM, ao passo que a cláusula HAVING filtra o retorno do agrupamento.

`````sql
SELECT TOP 100
	[Categoria].[Id],
    [Categoria].[Nome],
    COUNT([Curso].[CategoriaId]) AS [Cursos]
FROM    
    [Categoria]
    INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY
	[Categoria].[Id],
    [Categoria].[Nome],
    [Curso].[CategoriaId]
-- Não podemos usar WHERE depois de GROUP BY
`````

````sql
SELECT TOP 100
	[Categoria].[Id],
    [Categoria].[Nome],
    COUNT([Curso].[CategoriaId]) AS [Cursos]
FROM    
    [Categoria]
    INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY
	[Categoria].[Id],
    [Categoria].[Nome],
    [Curso].[CategoriaId]
-- Mas podemos usar a cláusula HAVING
HAVING -- Contendo
	COUNT([Curso].[CategoriaId]) > 1
````

