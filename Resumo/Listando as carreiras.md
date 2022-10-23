## Listando as carreiras

````SQL
-- Exibir carreiras
SELECT 
    [Id],
    [Title],
    [Url],
    -- Maneira menos recomendada de exibir a quantidade de cursos em cada carreira
    -- SubSelect
    (SELECT COUNT([CareerId]) FROM [CareerItem] WHERE [CareerId] = [Id])
FROM
    [Career]
````

````sql
SELECT
	[Career].[Id],
	[Career].[Title],
	[Career].[Url],
	COUNT([Id]) AS [Courses]
FROM
	[Career]
	INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
GROUP BY
	[Career].[Id],
	[Career].[Title],
	[Career].[Url]
````

````sql
CREATE OR ALTER VIEW vwCareers AS
	SELECT
        [Career].[Id],
        [Career].[Title],
        [Career].[Url],
        COUNT([Id]) AS [Courses]
    FROM
        [Career]
        INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
    GROUP BY
        [Career].[Id],
        [Career].[Title],
        [Career].[Url]
````

