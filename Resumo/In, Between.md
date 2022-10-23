## In, Between

### In

```sql
SELECT TOP 100
   *
FROM    
    [Curso]
WHERE   
	-- Traz se o valor está presente na coluna
    [Id] IN (1, 3)
```

````sql
SELECT TOP 100
   *
FROM    
    [Curso]
WHERE   
	-- Podemos ter um SELECT dentro do IN para queries mais complexas
    [Id] IN (SELECT [Id] FROM [Categoria])
````

### Between

````sql
SELECT TOP 100
   *
FROM    
    [Curso]
WHERE   
	-- Traz se o valor está entre os valores
    [Id] BETWEEN 2 AND 3
````

````sql
SELECT TOP 100
   *
FROM    
    [Curso]
WHERE   
	-- Traz se o valor está entre os valores
    [Id] BETWEEN '2020-03-01' AND '2020-03-31'
--  [Id] BETWEEN '2020-03-01 00:00:00' AND '2020-03-31 23:59:00'
````

