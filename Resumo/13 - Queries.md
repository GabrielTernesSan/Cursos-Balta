## Queries

````sql
SELECT TOP 100
	[Id], [Nome], [CategoriaId]
FROM
	[Curso]
WHERE 
	[CategoriaId] != 1
  -- [CategoriaId] < 1
  -- [CategoriaId] > 1
  -- [CategoriaId] = 1
````

### AND

````sql
SELECT TOP 100
	[Id], [Nome], [CategoriaId]
FROM
	[Curso]
WHERE 
	[Id] = 1 AND
	[CategoriaId] = 1 
	
````

### OR

````sql
SELECT TOP 100
	[Id], [Nome], [CategoriaId]
FROM
	[Curso]
WHERE 
	[Id] = 1 OR
	[CategoriaId] = 1 
````

### IS NULL

````sql
SELECT TOP 100
	[Id], [Nome], [CategoriaId]
FROM
	[Curso]
WHERE 
	[Id] = 1 OR
	[CategoriaId] IS NULL
````

### IS NOT NULL

`````sql
SELECT TOP 100
	[Id], [Nome], [CategoriaId]
FROM
	[Curso]
WHERE 
	[Id] = 1 OR
	[CategoriaId] IS NOT NULL
`````

