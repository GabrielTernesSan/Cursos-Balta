## Select

`````SQL
-- Evite ao máximo usar o "*" para não travar o banco
SELECT * FROM [Curso]

-- Em vez de usar somente o "*", use em conjunto com o "TOP"
SELECT TOP 2 * FROM [Curso]
-- Assim você tem a garantia que em um banco com 1M de registros não irá travar
`````

````sql
-- Sintaxe + filtros. NUNCA USE O "*"
SELECT TOP 2
	-- Mantenha a ordem da tabela
	[Id], [Nome]
FROM
	[Curso]

-- O "DISTINCT" traz somente dados distintos
SELECT DISTINCT TOP 2
	[Id], [Nome]
FROM
	[Curso]
````

