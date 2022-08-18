## Listando os cursos

````sql
USE [balta]
GO

SELECT  
    [Id],
    [Tag],
    [Title],
    [Summary]
FROM
    [Course]
WHERE
    [Active] = 1
ORDER BY 
    [CreateDate] DESC
````

`````sql
SELECT  
    [Course].[Id],
    [Course].[Tag],
    [Course].[Title],
    [Course].[Summary],
    [Category].[Title]
FROM
    [Course]
    INNER JOIN [Category] ON [Course].[CategoryId] = [Category].[Id]
WHERE
    [Active] = 1
ORDER BY 
    [CreateDate] DESC
`````

`````sql
SELECT  
    [Course].[Id],
    [Course].[Tag],
    [Course].[Title],
    [Course].[Summary],
    [Category].[Title],
    [Author].[Name]
FROM
    [Course]
    INNER JOIN [Category] ON [Course].[CategoryId] = [Category].[Id]
    INNER JOIN [Author] ON [Course].[AuthorId] = [Author].[Id]
WHERE
    [Active] = 1
ORDER BY 
    [CreateDate] DESC
`````

````sql
-- Para criar uma View não podemos ter ORDER BY
CREATE OR ALTER VIEW vwCourses AS
    SELECT  
        [Course].[Id],
        [Course].[Tag],
        [Course].[Title],
        [Course].[Summary],
        [Course].[CreateDate],
        [Category].[Title] AS [Category],
        [Author].[Name] AS [Author]
    FROM
        [Course]
        INNER JOIN [Category] ON [Course].[CategoryId] = [Category].[Id]
        INNER JOIN [Author] ON [Course].[AuthorId] = [Author].[Id]
    WHERE
        [Active] = 1
````

````sql
-- Mas podemos ter depois, adicionando a cláusula SELECT o parâmetro
SELECT * FROM vwCourses ORDER BY [CreateDate] DESC
````

